using Greenlight.Data.Contexts;
using Greenlight.Models;
using Greenlight.Services;
using Microsoft.AspNetCore.Mvc;

namespace Greenlight.Controller
{

    [ApiController]
    [Route("Instalar")]
    public class InstalarController : ControllerData
    {

        private readonly InstalarServices instalarServices;

        public InstalarController(IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
            instalarServices = new InstalarServices(databaseContext, _configuration);
        }

        [HttpPost]
        public async Task<ActionResult<InstalarServicesResposta>> Instalar()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultController<InstalarServicesResposta>("Erro ao carregar chamada"));

            var resposta = await this.instalarServices.Instalar();
            if (resposta.Erro)
                return BadRequest(new ResultController<InstalarServicesResposta>(resposta.Mensagem));

            return Ok(new { mensagem = "Instalacao bem sucedida" });
        }





    }
}
