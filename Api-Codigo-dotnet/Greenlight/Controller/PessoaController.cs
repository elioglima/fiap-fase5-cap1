using Greenlight.Data.Contexts;
using Greenlight.Models;
using Greenlight.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Controller
{

    [ApiController]
    [Route("pessoa")]
    [Authorize]
    public class PessoaController : ControllerData
    {

        private readonly PessoaServices pessoaServices;

        public PessoaController(IConfiguration _configuration, DatabaseContext databaseContext) : base(_configuration, databaseContext)
        {
            pessoaServices = new PessoaServices(databaseContext);
        }

        [HttpGet]
        public async Task<ActionResult<PessoaServiceResposta>> BuscarTodos()
        {
            var resposta = await this.pessoaServices.BuscarTodos();
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaServiceResposta>("Erro ao carregar chamada"));

            return Ok(resposta.Lista);
        }


        [HttpGet("fisica")]
        public async Task<ActionResult<PessoaFisicaServiceResposta>> BuscarPessoaFisicaTodos()
        {
            var resposta = await this.pessoaServices.BuscarPessoaFisicaTodos();
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaFisicaServiceResposta>("Erro ao carregar chamada"));

            return Ok(resposta.Lista);
        }

        [HttpGet("juridica")]
        public async Task<ActionResult<PessoaFisicaServiceResposta>> BuscarPessoaJuridicaTodos()
        {
            var resposta = await this.pessoaServices.BuscarPessoaJuridicaTodos();
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaFisicaServiceResposta>("Erro ao carregar chamada"));

            return Ok(resposta.Lista);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PessoaServiceResposta>> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultController<PessoaServiceResposta>("Erro ao carregar chamada"));

            var resposta = await this.pessoaServices.BuscarPorId(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaServiceResposta>("Erro ao carregar chamada"));

            return Ok(resposta.Registro);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaServiceResposta>> Post(PessoaServiceRequisicao Dados)
        {
            var resposta = await this.pessoaServices.Adicionar(Dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaServiceResposta>("Erro ao carregar chamada"));

            return Ok(Created($"/pessoa/{resposta.Registro.Id}", resposta.Registro));
        }

        [HttpPost("fisica")]
        public async Task<ActionResult<PessoaFisicaServiceResposta>> Post(PessoaFisicaServiceRequisicao Dados)
        {
            var resposta = await this.pessoaServices.AdicionarPessoaFisica(Dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaFisicaServiceResposta>(resposta.Mensagem));

            return Ok(Created($"/pessoa/{resposta.Registro.Id}", resposta.Registro));
        }

        [HttpPost("juridica")]
        public async Task<ActionResult<PessoaJuridicaServiceResposta>> Post(PessoaJuridicaServiceRequisicao Dados)
        {
            var resposta = await this.pessoaServices.AdicionarPessoaJuridica(Dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaJuridicaServiceResposta>("Erro ao carregar chamada"));

            return Ok(Created($"/pessoa/{resposta.Registro.Id}", resposta.Registro));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PessoaServiceResposta>> Put(int id, PessoaServiceRequisicao dados)
        {
            var resposta = await this.pessoaServices.AtualizarPessoa(id, dados);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaServiceResposta>("Erro ao carregar chamada"));

            return Ok(Created($"/pessoa/{resposta.Registro.Id}", resposta.Registro));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PessoaServiceResposta>> Delete(int id)
        {
            var resposta = await this.pessoaServices.RemoverPessoa(id);
            if (resposta.Erro == true)
                return BadRequest(new ResultController<PessoaServiceResposta>("Erro na execucao da chamada"));

            return NoContent();
        }


    }
}
