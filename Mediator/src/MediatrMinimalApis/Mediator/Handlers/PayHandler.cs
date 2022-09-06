using MediatR;
using MediatrMinimalApis.Mediator.Commands;
using MediatrMinimalApis.Persistence;

namespace MediatrMinimalApis.Mediator.Handlers
{
    public sealed class PayHandler : IRequestHandler<PayCommand, bool>
    {
        private readonly InMemoryDbContext _context;

        public PayHandler(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(PayCommand request, CancellationToken cancellationToken)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == request.Id);

            if (payment == null)
                return await Task.FromResult(false);

            payment.Pay();

            return await Task.FromResult(true);
        }
    }
}
