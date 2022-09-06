namespace WithoutLibs.Base
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand
    {
        TResponse Handle(TCommand command);
    }
}
