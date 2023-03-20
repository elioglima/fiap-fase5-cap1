using Greenlight.Data.Applications;

namespace Greenlight.Data.Applications
{
    public static class ResolveSwaggerMiddleware
    {
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }


    }
}
