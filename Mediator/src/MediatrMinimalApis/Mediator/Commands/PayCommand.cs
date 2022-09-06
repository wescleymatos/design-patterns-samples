using MediatR;

namespace MediatrMinimalApis.Mediator.Commands
{
    public sealed class PayCommand : IRequest<bool>
    {
        public PayCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}
