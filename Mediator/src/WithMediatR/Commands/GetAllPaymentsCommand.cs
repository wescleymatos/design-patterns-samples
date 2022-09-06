using MediatR;
using WithMediatR.Persistence.Entities;

namespace WithMediatR.Commands
{
    public class GetAllPaymentsCommand : IRequest<List<Payment>>
    {
    }
}
