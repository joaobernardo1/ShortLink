using ShortLink.Domain.Repository;

namespace ShortLink.Infrastructure.DataAccess
{
    internal class UnityOfWork : IUnityOfWork
    {
        private readonly ShortLinkDbContext _dbContext;

        public UnityOfWork(ShortLinkDbContext dbContext)
        {
            _dbContext = dbContext;
        }   
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
