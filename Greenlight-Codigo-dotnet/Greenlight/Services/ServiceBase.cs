using Greenlight.Data.Contexts;

namespace Greenlight.Services
{
    public class ServiceBase
    {
        protected readonly DatabaseContext db;
        protected IConfiguration Configuration;

        public ServiceBase(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
    }
}
