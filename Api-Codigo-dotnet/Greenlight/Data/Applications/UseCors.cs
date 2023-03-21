using Greenlight.Data.Applications;

namespace Greenlight.Data.Applications
{
    public static class ResolveUseCors
    {

        public static IApplicationBuilder UseCors(this IApplicationBuilder app)
        {
            app.UseCors(p =>
            {
                p.AllowAnyOrigin();
                p.WithMethods("GET");
                p.AllowAnyHeader();
            });

            return app;
        }


    }
}
