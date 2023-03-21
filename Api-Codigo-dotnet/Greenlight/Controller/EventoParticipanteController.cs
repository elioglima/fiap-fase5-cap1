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


        private readonly EventoParticipanteServices eventoParticipanteServices;

        public EventoParticipanteController(IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
            eventoParticipanteServices = new EventoParticipanteServices(databaseContext);
        }

        [HttpGet]
        public async Task<ActionResult<EventoParticipanteServiceResposta>> BuscarTodos()
        {
            var resposta = await this.eventoParticipanteServices.BuscarTodos();
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoParticipanteServiceResposta>(resposta.Mensagem));

            return Ok(resposta.Lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventoParticipanteServiceResposta>> BuscarPorId(int id)
        {
            var resposta = await this.eventoParticipanteServices.BuscarPorId(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoParticipanteServiceResposta>(resposta.Mensagem));

            return Ok(resposta.Registro);
        }

        [HttpPost]
        public async Task<ActionResult<EventoParticipanteServiceResposta>> Adicionar(EventoParticipanteServiceRequisicao Dados)
        {
            var resposta = await this.eventoParticipanteServices.Adicionar(Dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoParticipanteServiceResposta>(resposta.Mensagem));

            return Ok(Created($"/endereco/{resposta.Registro.Id}", resposta.Registro));
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<EventoParticipanteServiceResposta>> Atualizar(int id, EventoParticipanteServiceRequisicao dados)
        {
            var resposta = await this.eventoParticipanteServices.Atualizar(id, dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoParticipanteServiceResposta>("Erro ao carregar chamada"));

            return Ok(Created($"/endereco/{resposta.Registro.Id}", resposta.Registro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EventoParticipanteServiceResposta>> Remover(int id)
        {
            var resposta = await this.eventoParticipanteServices.Remover(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EventoParticipanteServiceResposta>("Erro na execucao da chamada"));

            return NoContent();
        }



    }
}
