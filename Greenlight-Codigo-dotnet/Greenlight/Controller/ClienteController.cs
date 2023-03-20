using Greenlight.Data.Contexts;
using Greenlight.Models;
using Greenlight.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenlight.Controller
{

    [ApiController]
    [Route("usuario")]
    
    public class ClienteController : ControllerData
    {
        private readonly ClienteServices clienteServices;

        public ClienteController(ITokenService TokenService, IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
            clienteServices = new ClienteServices(databaseContext, Configuration);
        }

        [HttpPost("entrar")]
        [AllowAnonymous]
        public async Task<ActionResult<ClienteServiceResposta>> Post(string email, string senha)
        {
            var resposta = await this.clienteServices.EntrarSistema(email, senha);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<ClienteServiceResposta>(resposta.Mensagem));

            return Ok(new { token = resposta.Token });            
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<ActionResult<ClienteServiceResposta>> Post(int id, string email, string senha)
        {
            var resposta = await this.clienteServices.Registrar(id, email, senha);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<ClienteServiceResposta>(resposta.Mensagem));

            return Ok(new { token = resposta.Token, cliente = resposta.Registro });
        }


    }
}
