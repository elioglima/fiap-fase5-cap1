using Greenlight.Data.Contexts;
using Greenlight.Entitys;
using Greenlight.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Services
{
    public class EventoServices : ServiceBase, IServiceController<Evento, EventoServiceResposta, EventoServiceRequisicao>
    {
        private DbSet<Evento> eventoRepository;

        public EventoServices(DatabaseContext databaseContext) : base(databaseContext)
        {
            eventoRepository = db.Evento;
        }

        public async Task<EventoServiceResposta> BuscarPorId(int Id)
        {
            try
            {
                var dados = await eventoRepository.FindAsync(Id);
                if (dados is null)
                    return new EventoServiceResposta(true, "EventoServiceResposta :: Registro nao localizado");

                return new EventoServiceResposta(dados, "EventoServices :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new EventoServiceResposta(true, "EventoServices :: Nao foi possivel consultar os dados.");
            }
        }

        public async Task<EventoServiceResposta> BuscarTodos()
        {
            try
            {
                var dados = await eventoRepository.ToListAsync();
                if (dados is null)
                    return new EventoServiceResposta(true, "EventoServiceResposta :: Registro nao localizado");

                return new EventoServiceResposta(dados, "EventoServiceResposta :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new EventoServiceResposta(true, "EventoServiceResposta :: Nao foi possivel consultar os dados.");
            }
        }

        public async Task<EventoServiceResposta> Adicionar(EnderecoServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {
                    dados.Id = 0;
                    endererecoRepository.Add(dados);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EnderecoServiceResposta(dados, "EnderecoServices :: Dados gravados com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EnderecoServiceResposta(true, ex.Message);
                }
            }
        }

        public async Task<EnderecoServiceResposta> Atualizar(int id, EnderecoServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    var registroLocalizado = await endererecoRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new EnderecoServiceResposta(dados, "EnderecoServices :: Associacao nao localizada.");

                    registroLocalizado.Logradouro = dados.Logradouro;
                    registroLocalizado.CEP = dados.CEP;
                    registroLocalizado.Numero = dados.Numero;
                    registroLocalizado.Complemento = dados.Complemento;
                    registroLocalizado.Bairro = dados.Bairro;
                    registroLocalizado.Cidade = dados.Cidade;
                    registroLocalizado.Pais = dados.Pais;
                    registroLocalizado.Estado = dados.Estado;
                    registroLocalizado.UF = dados.UF;
                    registroLocalizado.CodigoInstalacao = dados.CodigoInstalacao;

                    endererecoRepository.Update(registroLocalizado);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EnderecoServiceResposta(registroLocalizado, "EnderecoServices :: Dados Alterados com sucesso.");
                }
                catch (Exception)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EnderecoServiceResposta(true, "EnderecoServices :: Falha ao alterar os dados.");
                }
            }
        }

        public async Task<EnderecoServiceResposta> Remover(int id)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    var registroLocalizado = await endererecoRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new EnderecoServiceResposta(true, "EnderecoServices :: Pessoa nao localizada.");

                    endererecoRepository.Remove(registroLocalizado);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EnderecoServiceResposta(registroLocalizado, "EnderecoServices :: Dados apagado com sucesso.");
                }
                catch (Exception)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EnderecoServiceResposta(true, "EnderecoServices :: Falha ao alterar os dados.");
                }
            }
        }
    }
}
