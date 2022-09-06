using MediatR;
using WithMediatR.Commands;
using WithMediatR.Persistence;
using WithMediatR.Persistence.Entities;

namespace WithMediatR.Handlers
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsCommand, List<Payment>>
    {
        private readonly InMemoryDbContext _context;

        public GetAllPaymentsHandler(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> Handle(GetAllPaymentsCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Payments);
        }
    }
}
