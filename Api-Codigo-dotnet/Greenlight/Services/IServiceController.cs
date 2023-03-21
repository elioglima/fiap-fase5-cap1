using Greenlight.Models;

namespace Greenlight.Services
{
    public interface IServiceController<Entidade, Resposta, Requisicao>
    {
        public Task<Resposta> BuscarPorId(int Id);
        
        public Task<Resposta> BuscarTodos();

        public Task<Resposta> Adicionar(Requisicao dados);

        public Task<Resposta> Atualizar(int id, Requisicao dados);
        
        public Task<Resposta> Remover(int id);

    }
}