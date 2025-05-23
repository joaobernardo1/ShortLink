
using ShortLink.Domain.Entities;
using ShortLink.Domain.Repository.ShortLink;

namespace ShortLink.Application.UseCase.Redirect
{
    public class RedirectUseCase : IRedirectUseCase
    {
        private readonly IShortLinkReadOnly _repository;

        public RedirectUseCase(IShortLinkReadOnly repository)
        {
            _repository = repository;
        }
        public async Task<string?> Execute(string shortLink)
        {
            var link = await _repository.GetUrlByShortLink(shortLink);
            if (link == null)
            {
                throw new Exception("Link not found");
            }
            return link.LongLink;
        }
    }
}
