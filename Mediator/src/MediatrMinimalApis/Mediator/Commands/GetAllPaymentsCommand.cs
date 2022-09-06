using MediatR;
using MediatrMinimalApis.Persistence.Entities;

namespace MediatrMinimalApis.Mediator.Commands
{
    public sealed class GetAllPaymentsCommand : IRequest<List<Payment>>
    {
    }
}
