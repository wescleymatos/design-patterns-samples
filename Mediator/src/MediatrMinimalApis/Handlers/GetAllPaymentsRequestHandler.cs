using MediatR;
using MediatrMinimalApis.Persistence;
using MediatrMinimalApis.Requests;

namespace MediatrMinimalApis.Handlers
{
    public class GetAllPaymentsRequestHandler : IRequestHandler<GetAllPaymentsRequest, IResult>
    {
        private readonly InMemoryDbContext _context;

        public GetAllPaymentsRequestHandler(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(GetAllPaymentsRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(100);
            return Results.Ok(_context.Payments);
        }
    }
}
