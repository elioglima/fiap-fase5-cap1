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


        private readonly EventoServices eventoServices;

        public EventoController(IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
            eventoServices = new EventoServices(databaseContext);
        }

        [HttpGet]
        public async Task<ActionResult<EventoServiceResposta>> BuscarTodos()
        {
            var resposta = await this.eventoServices.BuscarTodos();
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoServiceResposta>(resposta.Mensagem));

            return Ok(resposta.Lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventoServiceResposta>> BuscarPorId(int id)
        {
            var resposta = await this.eventoServices.BuscarPorId(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoServiceResposta>(resposta.Mensagem));

            return Ok(resposta.Registro);
        }

        [HttpPost]
        public async Task<ActionResult<EventoServiceResposta>> Adicionar(EventoServiceRequisicao Dados)
        {
            var resposta = await this.eventoServices.Adicionar(Dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoServiceResposta>(resposta.Mensagem));

            return Ok(Created($"/endereco/{resposta.Registro.Id}", resposta.Registro));
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<EventoServiceResposta>> Atualizar(int id, EventoServiceRequisicao dados)
        {
            var resposta = await this.eventoServices.Atualizar(id, dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoServiceResposta>("Erro ao carregar chamada"));

            return Ok(Created($"/endereco/{resposta.Registro.Id}", resposta.Registro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EventoServiceResposta>> Remover(int id)
        {
            var resposta = await this.eventoServices.Remover(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoServiceResposta>("Erro na execucao da chamada"));

            return NoContent();
        }


    }
}
