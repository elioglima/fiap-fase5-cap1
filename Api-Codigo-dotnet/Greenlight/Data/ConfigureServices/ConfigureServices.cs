using Greenlight.Data.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Greenlight.Data.Configurations.ConfigureServices
{
    public static class ResolveConfigureServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.SwaggerConfig();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();

            var conectionString = builder.Configuration.GetConnectionString("DefaultConection");
            
            builder.Services.AddDbContext<DatabaseContext>(options =>
                        options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

            builder.Services.InjectionServices();
            builder.Services.AuthenticationConfig(builder);
            builder.Services.AddJsonMvcConfigure();




        }
    }
}