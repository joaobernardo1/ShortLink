using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Entities;

namespace ShortLink.Infrastructure.DataAccess
{
    internal class ShortLinkDbContext :DbContext
    {
        public ShortLinkDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Link> Links { get; set; }
    }
}
