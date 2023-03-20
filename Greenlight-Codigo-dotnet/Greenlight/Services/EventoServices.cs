using Greenlight.Data.Contexts;
using Greenlight.Entitys;
using Greenlight.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Services
{
    public class EventoParticipanteServices : ServiceBase, IServiceController<EventoParticipante, EventoParticipanteServiceResposta, EventoParticipanteServiceRequisicao>
    {
        private DbSet<EventoParticipante> eventoParticipanteRepository;

        public EventoParticipanteServices(DatabaseContext databaseContext) : base(databaseContext)
        {
            eventoParticipanteRepository = db.EventoParticipante;
        }

        public async Task<EventoParticipanteServiceResposta> BuscarPorId(int Id)
        {
            try
            {
                var dados = await eventoParticipanteRepository.FindAsync(Id);
                if (dados is null)
                    return new EventoParticipanteServiceResposta(true, "EventoParticipanteServices :: Registro nao localizado");

                return new EventoParticipanteServiceResposta(dados, "EventoParticipanteServices :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new EventoParticipanteServiceResposta(true, "EventoParticipanteServices :: Nao foi possivel consultar os dados.");
            }
        }

        public async Task<EventoParticipanteServiceResposta> BuscarTodos()
        {
            try
            {
                var dados = await eventoParticipanteRepository.ToListAsync();
                if (dados is null)
                    return new EventoParticipanteServiceResposta(true, "EventoServices :: Registro nao localizado");

                return new EventoParticipanteServiceResposta(dados, "EventoServices :: Processo de consulta concluido.");
            }
            catch (Exception)
            {

                return new EventoParticipanteServiceResposta(true, "EventoServices :: Nao foi possivel consultar os dados.");
            }
        }

        public async Task<EventoParticipanteServiceResposta> Adicionar(EventoParticipanteServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {
                    dados.Id = 0;
                    eventoParticipanteRepository.Add(dados);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EventoParticipanteServiceResposta(dados, "EventoServices :: Dados gravados com sucesso.");
                }
                catch (Exception ex)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EventoParticipanteServiceResposta(true, ex.Message);
                }
            }
        }

        public async Task<EventoParticipanteServiceResposta> Atualizar(int id, EventoParticipanteServiceRequisicao dados)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    var registroLocalizado = await eventoParticipanteRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new EventoParticipanteServiceResposta(dados, "EventoServices :: Associacao nao localizada.");

                    registroLocalizado.EventoId = dados.EventoId;
                    registroLocalizado.PessoaId = dados.PessoaId;
                    
                    eventoParticipanteRepository.Update(registroLocalizado);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EventoParticipanteServiceResposta(registroLocalizado, "EventoServices :: Dados Alterados com sucesso.");
                }
                catch (Exception)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EventoParticipanteServiceResposta(true, "EventoServices :: Falha ao alterar os dados.");
                }
            }
        }

        public async Task<EventoParticipanteServiceResposta> Remover(int id)
        {
            using (await db.Database.BeginTransactionAsync())
            {
                try
                {

                    var registroLocalizado = await eventoParticipanteRepository.FindAsync(id);
                    if (registroLocalizado is null)
                        return new EventoParticipanteServiceResposta(true, "EventoServices :: Pessoa nao localizada.");

                    eventoParticipanteRepository.Remove(registroLocalizado);
                    await db.SaveChangesAsync();
                    await db.Database.CommitTransactionAsync();
                    return new EventoParticipanteServiceResposta(registroLocalizado, "EventoServices :: Dados apagado com sucesso.");
                }
                catch (Exception)
                {
                    await db.Database.RollbackTransactionAsync();
                    return new EventoParticipanteServiceResposta(true, "EventoServices :: Falha ao alterar os dados.");
                }
            }
        }
    }
}
