using Microsoft.Extensions.DependencyInjection;
using ShortLink.Application.AutoMapper;
using ShortLink.Application.UseCase.Create;
using ShortLink.Application.UseCase.Redirect;

namespace ShortLink.Application
{
    public static class DependencyInjectionUseCase
    {
        public static void AddApplication(this IServiceCollection service)
        {
            AddUseCase(service);
            AddAutoMapper(service);
        }

        public static void AddUseCase(IServiceCollection service)
        {
            service.AddScoped<ICreateShortLinkUseCase, CreateShortLinkUseCase>();
            service.AddScoped<IRedirectUseCase, RedirectUseCase>();
        }

        public static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapping));
        }
    }
}
