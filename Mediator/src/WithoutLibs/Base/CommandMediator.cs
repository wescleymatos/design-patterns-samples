namespace WithoutLibs.Base
{
    public interface ICommandMediator
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }

    public class CommandMediator : ICommandMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandMediator(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            _serviceProvider = serviceProvider;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            try
            {
                ICommandHandler<ICommand> handler = (ICommandHandler<ICommand>)_serviceProvider.GetService(handlerType);
                handler.Handle(command);
            }
            catch (Exception ex)
            {

                throw new HandlerNotFoundException(ex);
            }
        }

        public TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            try
            {
                dynamic handler = _serviceProvider.GetService(handlerType);
                return handler.Handle((dynamic)command);
            }
            catch (Exception ex)
            {

                throw new HandlerNotFoundException(ex);
            }
        }
    }
    }
