using Greenlight.Data.Contexts;
using Greenlight.Entitys;
using Greenlight.Models;

namespace Greenlight.Services
{
    public class InstalarServices : ServiceBase
    {

        private readonly PessoaServices pessoaServices;
        private readonly ClienteServices clienteServices;
        private readonly EnderecoServices enderecoServices;

        public InstalarServices(DatabaseContext databaseContext, IConfiguration _configuration) : base(databaseContext)
        {
            pessoaServices = new PessoaServices(databaseContext);
            clienteServices = new ClienteServices(databaseContext, _configuration);
            enderecoServices = new EnderecoServices(databaseContext);
        }

        public async void Instalar()
        {
        /*
         * 
         * var associacaoResposta = await associacaoServices.Adicionar(new AssociacaoServiceRequisicao() { Id = 0, Nome = "Associação Matriz" });
            if (associacaoResposta.Erro)
                return new InstalarServicesResposta(true, associacaoResposta.Mensagem);
            var energiaStatus = await energiaStatusServices.BuscarPorId(1);
            if (energiaStatus.Erro)
            {
                await energiaStatusServices.Adicionar(new EnergiaStatusServiceRequisicao()
                {
                    Id = 1,
                    Descricao = "Processando",
                });

                await energiaStatusServices.Adicionar(new EnergiaStatusServiceRequisicao()
                {
                    Id = 2,
                    Descricao = "Ativo",
                });

                await energiaStatusServices.Adicionar(new EnergiaStatusServiceRequisicao()
                {
                    Id = 3,
                    Descricao = "Inativo",
                });

                await energiaStatusServices.Adicionar(new EnergiaStatusServiceRequisicao()
                {
                    Id = 4,
                    Descricao = "Transferido",
                });

                await energiaStatusServices.Adicionar(new EnergiaStatusServiceRequisicao()
                {
                    Id = 5,
                    Descricao = "Cancelado",
                });

                await energiaStatusServices.Adicionar(new EnergiaStatusServiceRequisicao()
                {
                    Id = 6,
                    Descricao = "Expirado",
                });
            }



            var concessionaResposta = await concessionariaServices.BuscarPorId(1);
            if (concessionaResposta.Erro)
            {
                concessionaResposta = await concessionariaServices.Adicionar(new ConcessionariaServiceRequisicao()
                {
                    Id = 0,
                    RazaoSocial = "Enel Distribuição São Paulo",
                    CNPJ = "64257907000113",
                    IE = "325776742677",
                });

                if (concessionaResposta.Erro)
                    return new InstalarServicesResposta(true, concessionaResposta.Mensagem);

            }


            var primeiroUsuario = await this.AdicionarPrimeiroUsuario(associacaoResposta, concessionaResposta);
            if (primeiroUsuario.Erro)
                return new InstalarServicesResposta(true, primeiroUsuario.Mensagem);

            var segundoUsuario = await this.AdicionarSegundoUsuario(associacaoResposta, concessionaResposta);
            if (segundoUsuario.Erro)
                return new InstalarServicesResposta(true, segundoUsuario.Mensagem);

            return new InstalarServicesResposta("Sucesso");
        */

        }
                
    }
}
