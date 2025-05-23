using ShortLink.Domain.Entities;

namespace ShortLink.Domain.Repository.ShortLink
{
    public interface IShortLinkWriteOnly
    {
        public Task Add(Link link);
    }
}
