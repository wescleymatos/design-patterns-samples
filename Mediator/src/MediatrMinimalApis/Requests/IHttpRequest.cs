using MediatR;

namespace MediatrMinimalApis.Requests
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
