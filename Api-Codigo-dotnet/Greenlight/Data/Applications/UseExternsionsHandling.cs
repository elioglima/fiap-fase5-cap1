using Greenlight.Data.Applications;

namespace Greenlight.Data.Applications
{
    public static class ResolveUseExternsionsHandling
    {
        public static IApplicationBuilder UseExternsionsHandling(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            return app;
        }
    }
}
