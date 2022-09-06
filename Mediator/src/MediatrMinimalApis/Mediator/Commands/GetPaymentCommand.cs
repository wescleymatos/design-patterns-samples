using MediatR;
using MediatrMinimalApis.Persistence.Entities;

namespace MediatrMinimalApis.Mediator.Commands
{
    public sealed class GetPaymentCommand : IRequest<Payment?>
    {
        public GetPaymentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}
