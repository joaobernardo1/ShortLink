using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Entities;
using ShortLink.Domain.Repository.ShortLink;

namespace ShortLink.Infrastructure.DataAccess.Repository
{
    internal class ShortLinkRepository : IShortLinkWriteOnly, IShortLinkReadOnly
    {
        private readonly ShortLinkDbContext _dbContext;

        public ShortLinkRepository(ShortLinkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Link link)
        {
            await _dbContext.Links.AddAsync(link);
        }

        public async Task<Link?> GetUrlByShortLink(string shortLink)
        {
            var result = await _dbContext.Links.AsNoTracking().FirstOrDefaultAsync(x => x.ShortLink == shortLink);
            return result;
        }
    }
}
