using MediatR;
using MediatrMinimalApis.Requests;

namespace MediatrMinimalApis.Extensions
{
    public static class MinimalMediatRExtensions
    {
        public static WebApplication MediatRGet<TRequest>(this WebApplication app, string template) where TRequest : IHttpRequest
        {
            app.MapGet(template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
            return app;
        }

        public static WebApplication MediatRPost<TRequest>(this WebApplication app, string template) where TRequest : IHttpRequest
        {
            app.MapPost(template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
            return app;
        }
    }
}
