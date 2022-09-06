using MediatR;
using MediatrMinimalApis.Mediator.Commands;
using MediatrMinimalApis.Persistence;
using MediatrMinimalApis.Persistence.Entities;

namespace MediatrMinimalApis.Mediator.Handlers
{
    public sealed class GetPaymentHandler : IRequestHandler<GetPaymentCommand, Payment?>
    {
        private readonly InMemoryDbContext _context;

        public GetPaymentHandler(InMemoryDbContext context)
        {
            _context = context;
        }
        public async Task<Payment?> Handle(GetPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == request.Id);
            return await Task.FromResult(payment);
        }
    }
}
