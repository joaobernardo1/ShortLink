using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortLink.Domain.Repository;
using ShortLink.Domain.Repository.ShortLink;
using ShortLink.Infrastructure.DataAccess;
using ShortLink.Infrastructure.DataAccess.Repository;

namespace ShortLink.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            AddDbContext(service, config);
            AddRepository(service);
        }

        public static void AddDbContext(this IServiceCollection service, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Connection");
            var dbVersion = new Version(8, 0, 41);
            var serverVersion = new MySqlServerVersion(dbVersion);
            service.AddDbContext<ShortLinkDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }

        public static void AddRepository(this IServiceCollection service)
        {
            service.AddScoped<IShortLinkWriteOnly, ShortLinkRepository>();
            service.AddScoped<IShortLinkReadOnly, ShortLinkRepository>();
            service.AddScoped<IUnityOfWork, UnityOfWork>();
        }
    }
}
