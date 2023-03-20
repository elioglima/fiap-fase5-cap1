using Greenlight.Data.Contexts;
using Greenlight.Entitys;
using Greenlight.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Services
{
    public class ClienteServices : ServiceBase
    {
        private DbSet<Pessoa> pessoaRepository;
        private DbSet<Cliente> clienteRepository;
        private readonly TokenService tokenService;


        public ClienteServices(DatabaseContext databaseContext, IConfiguration _configuration) : base(databaseContext)
        {
            tokenService = new TokenService();
            pessoaRepository = db.Pessoa;
            clienteRepository = db.Cliente;
            Configuration = _configuration;
        }


        internal async Task<ClienteServiceResposta> EntrarSistema(string Email, string Senha)
        {
            try
            {
                var dados = await clienteRepository.FirstOrDefaultAsync(i => i.Email == Email && i.Senha == Senha); 
                if (dados is null)
                    return new ClienteServiceResposta(true, "ClienteServices :: Acesso restrito ao sistema");

                
                var tokenString = tokenService.GetToken(
                                           Configuration["Jwt:key"],
                                           Configuration["Jwt:Issuer"],
                                           Configuration["Jwt:Audience"],
                                           dados
                                    );

                return new ClienteServiceResposta(tokenString, "Acesso autorizado.");
            }
            catch (Exception)
            {
                return new ClienteServiceResposta(true, "ClienteServices :: Nao foi possivel consultar os dados.");
            }
        }

        internal async Task<ClienteServiceResposta> Registrar(int Id, string Email, string Senha)
        {

            var pessoaFind = await pessoaRepository.FindAsync(Id);
            if (pessoaFind is null)
            {
                return new ClienteServiceResposta(true, "Parametrêtros inválidos");
            }

            var clienteFind = await clienteRepository.FirstOrDefaultAsync(i => i.Email == Email);
            if (clienteFind is not null)
            {
                if (clienteFind.Id == Id)
                    return new ClienteServiceResposta(true, "O email ja esta cadastro, e paramêtros inválidos.");

                return new ClienteServiceResposta(true, "Email ja esta cadastro.");
            }

            using (await db.Database.BeginTransactionAsync())
            {
                try
                {
                    var dados = new Cliente();
                    dados.Id = pessoaFind.Id;
                    dados.Email = Email;
                    dados.Senha = Senha;

                    clienteRepository.Add(dados);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();

                    var respostaEntrar = await EntrarSistema(Email, Senha);
                    return new ClienteServiceResposta(dados, respostaEntrar.Token, "Cadatro efetuado com sucesso.");
                }
                catch (Exception)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new ClienteServiceResposta(true, "ClienteServices :: Falha ao gravar os dados.");
                }
            }
        }


        internal async Task<ClienteServiceResposta> BuscarPorId(int Id)
        {
            try
            {
                var dados = await clienteRepository.FindAsync(Id);
                if (dados is null)
                    return new ClienteServiceResposta(true, "ClienteServices :: Registro nao localizado");


                return new ClienteServiceResposta(dados, "PessoaServices :: Processo de consulta concluido.");
            }
            catch (Exception)
            {
                return new ClienteServiceResposta(true, "PessoaServices :: Nao foi possivel consultar os dados.");
            }
        }

        
    }
}
