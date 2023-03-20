using Greenlight.Data.Contexts;
using Greenlight.Models;
using Greenlight.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenlight.Controller
{
    [ApiController]
    [Route("participante")]
    [Authorize]
    public class EventoParticipanteController : ControllerData
    {
        

        public EventoParticipanteController(IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
        }

       
    }
}
