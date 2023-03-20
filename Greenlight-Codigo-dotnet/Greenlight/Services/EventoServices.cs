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
                    return new EventoServiceResposta(true, "EventoServices :: Registro nao localizado");

                return new EventoServiceResposta(dados, "EventoServices :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new EventoServiceResposta(true, "EventoServices :: Nao foi possivel consultar os dados.");
            }
        }

        public async Task<EventoServiceResposta> Adicionar(EventoServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {
                    dados.Id = 0;
                    eventoRepository.Add(dados);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EventoServiceResposta(dados, "EventoServices :: Dados gravados com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EventoServiceResposta(true, ex.Message);
                }
            }
        }

        public async Task<EventoServiceResposta> Atualizar(int id, EventoServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    var registroLocalizado = await eventoRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new EventoServiceResposta(dados, "EventoServices :: Associacao nao localizada.");

                    registroLocalizado.Descricao = dados.Descricao;
                    registroLocalizado.Texto = dados.Texto;
                    registroLocalizado.Data = dados.Data;

                    eventoRepository.Update(registroLocalizado);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EventoServiceResposta(registroLocalizado, "EventoServices :: Dados Alterados com sucesso.");
                }
                catch (Exception)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EventoServiceResposta(true, "EventoServices :: Falha ao alterar os dados.");
                }
            }
        }

        public async Task<EventoServiceResposta> Remover(int id)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    var registroLocalizado = await eventoRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new EventoServiceResposta(true, "EventoServices :: Pessoa nao localizada.");

                    eventoRepository.Remove(registroLocalizado);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EventoServiceResposta(registroLocalizado, "EventoServices :: Dados apagado com sucesso.");
                }
                catch (Exception)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EventoServiceResposta(true, "EventoServices :: Falha ao alterar os dados.");
                }
            }
        }
    }
}
