using ShortLink.Domain.Entities;

namespace ShortLink.Domain.Repository.ShortLink
{
    public interface IShortLinkReadOnly
    {
        public Task<Link> GetUrlByShortLink(string shortLink);
    }
}
