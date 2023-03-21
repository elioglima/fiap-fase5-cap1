using Greenlight.Data.Contexts;
using Greenlight.Models;
using Greenlight.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenlight.Controller
{

    [ApiController]
    [Route("endereco")]
    [Authorize]
    public class EnderecoController : ControllerData
    {
        
        private readonly EnderecoServices enderecoServices;

        public EnderecoController(IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
            enderecoServices = new EnderecoServices(databaseContext);
        }

        [HttpGet]
        public async Task<ActionResult<EnderecoServiceResposta>> BuscarTodos()
        {
            var resposta = await this.enderecoServices.BuscarTodos();
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EnderecoServiceResposta>(resposta.Mensagem));

            return Ok(resposta.Lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EnderecoServiceResposta>> BuscarPorId(int id)
        {
            var resposta = await this.enderecoServices.BuscarPorId(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EnderecoServiceResposta>(resposta.Mensagem));

            return Ok(resposta.Registro);
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoServiceResposta>> Adicionar(EnderecoServiceRequisicao Dados)
        {
            var resposta = await this.enderecoServices.Adicionar(Dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EnderecoServiceResposta>(resposta.Mensagem));

            return Ok(Created($"/endereco/{resposta.Registro.Id}", resposta.Registro));
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<EnderecoServiceResposta>> Atualizar(int id, EnderecoServiceRequisicao dados)
        {
            var resposta = await this.enderecoServices.Atualizar(id, dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EnderecoServiceResposta>("Erro ao carregar chamada"));

            return Ok(Created($"/endereco/{resposta.Registro.Id}", resposta.Registro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EnderecoServiceResposta>> Remover(int id)
        {
            var resposta = await this.enderecoServices.Remover(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<EnderecoServiceResposta>("Erro na execucao da chamada"));

            return NoContent();
        }
    }
}
