using WithoutLibs.Base;
using WithoutLibs.Commands;
using WithoutLibs.Persistence;
using WithoutLibs.Persistence.Entities;

namespace WithoutLibs.Handlers
{
    public class GetAllPaymentsHandler : ICommandHandler<GetAllPaymentsCommand, List<Payment>>
    {
        private readonly InMemoryDbContext _context;

        public GetAllPaymentsHandler(InMemoryDbContext context)
        {
            _context = context;
        }

        public List<Payment> Handle(GetAllPaymentsCommand command)
        {
            return _context.Payments;
        }
    }
}
