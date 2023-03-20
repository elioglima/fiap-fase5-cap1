using Greenlight.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Greenlight.Controller
{
    public class ControllerData : ControllerBase
    {
        protected readonly DatabaseContext db;
        protected IConfiguration Configuration;

        public ControllerData(IConfiguration _configuration, DatabaseContext databaseContext)
        {
            db = databaseContext;
            Configuration = _configuration;
        }


    }
}
