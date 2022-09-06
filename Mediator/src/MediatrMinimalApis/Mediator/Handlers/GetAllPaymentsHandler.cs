using MediatR;
using MediatrMinimalApis.Mediator.Commands;
using MediatrMinimalApis.Persistence;
using MediatrMinimalApis.Persistence.Entities;

namespace MediatrMinimalApis.Mediator.Handlers
{
    public sealed class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsCommand, List<Payment>>
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
