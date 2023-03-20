using Greenlight.Data.Contexts;
using Greenlight.Models;
using Greenlight.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenlight.Controller
{
    [ApiController]
    [Route("evento")]
    [Authorize]
    public class EventoController : ControllerData
    {
        

        public EventoController(IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
        }

       
    }
}
