using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Greenlight.Services;
using Microsoft.Extensions.Configuration;

namespace Greenlight.Data.Configurations.ConfigureServices
{
    public static class InjectionConfigServices
    {
        public static void InjectionServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();   
        }
    }
}