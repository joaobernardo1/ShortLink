using ShortLink.Domain.Entities;

namespace ShortLink.Application.UseCase.Redirect
{
    public interface IRedirectUseCase
    {
        public Task<string?> Execute(string shortLink);
    }
}
