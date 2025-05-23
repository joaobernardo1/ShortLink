using ShortLink.Communication.Request;
using ShortLink.Communication.Response;

namespace ShortLink.Application.UseCase.Create
{
    public interface ICreateShortLinkUseCase
    {
        public Task<ResponseShortLinkCreateJson> Execute(RequestShortLinkCreateJson requests);
    }
}
