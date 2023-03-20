using Greenlight.Data.Contexts;
using Greenlight.Entitys;
using Greenlight.Models;

namespace Greenlight.Services
{
    public class InstalarServices : ServiceBase
    {

        private readonly AssociacaoServices associacaoServices;
        private readonly PessoaServices pessoaServices;
        private readonly ClienteServices clienteServices;
        private readonly ConcessionariaServices concessionariaServices;
        private readonly EnderecoServices enderecoServices;
        private readonly EnergiaServices energiaServices;
        private readonly EnergiaStatusServices energiaStatusServices;

        public InstalarServices(DatabaseContext databaseContext, IConfiguration _configuration) : base(databaseContext)
        {
            associacaoServices = new AssociacaoServices(databaseContext);
            pessoaServices = new PessoaServices(databaseContext);
            clienteServices = new ClienteServices(databaseContext, _configuration);
            enderecoServices = new EnderecoServices(databaseContext);
            concessionariaServices = new ConcessionariaServices(databaseContext);
            energiaServices = new EnergiaServices(databaseContext);
            energiaStatusServices = new EnergiaStatusServices(databaseContext);
        }

        public async Task<InstalarServicesResposta> Instalar()
        {
            var associacaoResposta = await associacaoServices.Adicionar(new AssociacaoServiceRequisicao() { Id = 0, Nome = "Associação Matriz" });
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

        }

        private async Task<InstalarServicesResposta> AdicionarPrimeiroUsuario(AssociacaoServiceResposta associacaoResposta, ConcessionariaServiceResposta concessionaResposta)
        {
            // 1º = Pessoa
            var pessoaResposta = await pessoaServices.BuscarPorId(1);
            if (pessoaResposta.Erro)
            {

                pessoaResposta = await pessoaServices.Adicionar(new PessoaServiceRequisicao()
                {
                    Id = 0,
                    AssociacaoId = associacaoResposta.Registro.Id,
                    TipoPessoaId = 1,
                    PessoaFisica = new PessoaFisica()
                    {
                        Id = 0,
                        Nome = "Ana Aparecida da Silva",
                        CPF = "73422641050",
                        RG = "259076818",
                        DataNascimento = new DateTime(1979, 11, 04, 0, 0, 0)
                    }
                });

                if (pessoaResposta.Erro)
                    return new InstalarServicesResposta(true, pessoaResposta.Mensagem);
            }

            var clienteResposta = await clienteServices.BuscarPorId(1);
            if (clienteResposta.Erro)
            {
                clienteResposta = await clienteServices.Registrar(pessoaResposta.Registro.Id, "ana.aparecida@hotmail.com", "1234");

                if (clienteResposta.Erro)
                    return new InstalarServicesResposta(true, clienteResposta.Mensagem);
            }

            var enderecoResposta = await enderecoServices.BuscarPorId(1);
            if (enderecoResposta.Erro)
            {
                enderecoResposta = await enderecoServices.Adicionar(new EnderecoServiceRequisicao()
                {
                    Id = 0,
                    PessoaId = pessoaResposta.Registro.Id,
                    Logradouro = "Rua anastacio",
                    Numero = 142,
                    CEP = "03241000",
                    Complemento = "Casa",
                    Bairro = "Vila Oliveira",
                    Cidade = "Sao Paulo",
                    Estado = "Sao Paulo",
                    UF = "SP",
                    Pais = "Brasil",
                    CodigoInstalacao = "125554",
                });

                if (enderecoResposta.Erro)
                    return new InstalarServicesResposta(true, enderecoResposta.Mensagem);
            }


            var energiaResposta = await energiaServices.BuscarPorId(1);
            if (energiaResposta.Erro)
            {
                energiaResposta = await energiaServices.Adicionar(new EnergiaServiceRequisicao()
                {
                    Id = 0,
                    EnergiaStatusId = 1,
                    PessoaId = pessoaResposta.Registro.Id,
                    ConcessionariaId = concessionaResposta.Registro.Id,
                    EnderecoId = enderecoResposta.Registro.Id,
                    Saldo = (float?)1500.0,
                    Preco = (float?)1.25,
                    DataEntrada = new DateTime(2022, 8, 5),
                    DataValidade = new DateTime(2023, 8, 5),
                });

                if (energiaResposta.Erro)
                    return new InstalarServicesResposta(true, energiaResposta.Mensagem);
            }

            energiaResposta = await energiaServices.BuscarPorId(2);
            if (energiaResposta.Erro)
            {
                energiaResposta = await energiaServices.Adicionar(new EnergiaServiceRequisicao()
                {
                    Id = 0,
                    EnergiaStatusId = 2,
                    PessoaId = pessoaResposta.Registro.Id,
                    ConcessionariaId = concessionaResposta.Registro.Id,
                    EnderecoId = enderecoResposta.Registro.Id,
                    Saldo = (float?)1500.0,
                    Preco = (float?)1.25,
                    DataEntrada = new DateTime(2022, 9, 5),
                    DataValidade = new DateTime(2023, 9, 5),
                });

                if (energiaResposta.Erro)
                    return new InstalarServicesResposta(true, energiaResposta.Mensagem);
            }

            energiaResposta = await energiaServices.BuscarPorId(3);
            if (energiaResposta.Erro)
            {
                energiaResposta = await energiaServices.Adicionar(new EnergiaServiceRequisicao()
                {
                    Id = 0,
                    EnergiaStatusId = 6,
                    PessoaId = pessoaResposta.Registro.Id,
                    ConcessionariaId = concessionaResposta.Registro.Id,
                    EnderecoId = enderecoResposta.Registro.Id,
                    Saldo = (float?)1500.0,
                    Preco = (float?)1.25,
                    DataEntrada = new DateTime(2021, 9, 5),
                    DataValidade = new DateTime(2021, 9, 5),
                });

                if (energiaResposta.Erro)
                    return new InstalarServicesResposta(true, energiaResposta.Mensagem);
            }

            return new InstalarServicesResposta("Sucesso");

        }


        private async Task<InstalarServicesResposta> AdicionarSegundoUsuario(AssociacaoServiceResposta associacaoResposta, ConcessionariaServiceResposta concessionaResposta)
        {
            // 1º = Pessoa
            var pessoaResposta = await pessoaServices.BuscarPorId(2);
            if (pessoaResposta.Erro)
            {

                pessoaResposta = await pessoaServices.Adicionar(new PessoaServiceRequisicao()
                {
                    Id = 0,
                    AssociacaoId = associacaoResposta.Registro.Id,
                    TipoPessoaId = 1,
                    PessoaFisica = new PessoaFisica()
                    {
                        Id = 0,
                        Nome = "Roberto Alvares de Oliveira",
                        CPF = "36267381080",
                        RG = "383391325",
                        DataNascimento = new DateTime(1979, 11, 04, 0, 0, 0)
                    }
                });

                if (pessoaResposta.Erro)
                    return new InstalarServicesResposta(true, pessoaResposta.Mensagem);
            }

            var clienteResposta = await clienteServices.BuscarPorId(2);
            if (clienteResposta.Erro)
            {
                clienteResposta = await clienteServices.Registrar(pessoaResposta.Registro.Id, "roberto.alvares@hotmail.com", "1234");

                if (clienteResposta.Erro)
                    return new InstalarServicesResposta(true, clienteResposta.Mensagem);
            }

            var enderecoResposta = await enderecoServices.BuscarPorId(2);
            if (enderecoResposta.Erro)
            {
                enderecoResposta = await enderecoServices.Adicionar(new EnderecoServiceRequisicao()
                {
                    Id = 0,
                    PessoaId = pessoaResposta.Registro.Id,
                    Logradouro = "Rua joaquim",
                    Numero = 142,
                    CEP = "03245000",
                    Complemento = "Ap 21",
                    Bairro = "Vila Pimenta",
                    Cidade = "Sao Paulo",
                    Estado = "Sao Paulo",
                    UF = "SP",
                    Pais = "Brasil",
                    CodigoInstalacao = "22554",
                });

                if (enderecoResposta.Erro)
                    return new InstalarServicesResposta(true, enderecoResposta.Mensagem);
            }


            var energiaResposta = await energiaServices.BuscarPorId(4);
            if (energiaResposta.Erro)
            {
                energiaResposta = await energiaServices.Adicionar(new EnergiaServiceRequisicao()
                {
                    Id = 0,
                    EnergiaStatusId = 1,
                    PessoaId = pessoaResposta.Registro.Id,
                    ConcessionariaId = concessionaResposta.Registro.Id,
                    EnderecoId = enderecoResposta.Registro.Id,
                    Saldo = (float?)3500.0,
                    Preco = (float?)1.30,
                    DataEntrada = new DateTime(2022, 8, 5),
                    DataValidade = new DateTime(2023, 8, 5),
                });

                if (energiaResposta.Erro)
                    return new InstalarServicesResposta(true, energiaResposta.Mensagem);
            }

            energiaResposta = await energiaServices.BuscarPorId(4);
            if (energiaResposta.Erro)
            {
                energiaResposta = await energiaServices.Adicionar(new EnergiaServiceRequisicao()
                {
                    Id = 0,
                    EnergiaStatusId = 2,
                    PessoaId = pessoaResposta.Registro.Id,
                    ConcessionariaId = concessionaResposta.Registro.Id,
                    EnderecoId = enderecoResposta.Registro.Id,
                    Saldo = (float?)500.0,
                    Preco = (float?)4.25,
                    DataEntrada = new DateTime(2022, 9, 5),
                    DataValidade = new DateTime(2023, 9, 5),
                });

                if (energiaResposta.Erro)
                    return new InstalarServicesResposta(true, energiaResposta.Mensagem);
            }

            energiaResposta = await energiaServices.BuscarPorId(5);
            if (energiaResposta.Erro)
            {
                energiaResposta = await energiaServices.Adicionar(new EnergiaServiceRequisicao()
                {
                    Id = 0,
                    EnergiaStatusId = 6,
                    PessoaId = pessoaResposta.Registro.Id,
                    ConcessionariaId = concessionaResposta.Registro.Id,
                    EnderecoId = enderecoResposta.Registro.Id,
                    Saldo = (float?)7500.0,
                    Preco = (float?)2.25,
                    DataEntrada = new DateTime(2021, 9, 5),
                    DataValidade = new DateTime(2021, 9, 5),
                });

                if (energiaResposta.Erro)
                    return new InstalarServicesResposta(true, energiaResposta.Mensagem);
            }

            return new InstalarServicesResposta("Sucesso");

        }


        
    }
}
