using Greenlight.Data.Configurations.Configure;

namespace Greenlight.Data.Applications
{
    public static class ResulveApplicationConfigure
    {

        public static IApplicationBuilder Configure(this IApplicationBuilder app, IWebHostEnvironment environment)
        {

            app.UseExternsionsHandling(environment);
            app.UseSwaggerMiddleware();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();            
            return app;
        }


    }
}
