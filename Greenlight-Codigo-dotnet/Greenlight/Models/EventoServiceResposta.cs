using Greenlight.Entitys;

namespace Greenlight.Models
{

    public class EventoServiceResposta
    {
        public Evento? Registro;
        public List<Evento>? Lista;
        public string Mensagem;
        public bool Erro;

        public EventoServiceResposta(Evento registro, string mensagem)
        {
            Registro = registro;
            Mensagem = mensagem;
            Erro = false;
        }

        public EventoServiceResposta(bool erro, string mensagem)
        {
            Registro = null;
            Erro = erro;
            Mensagem = mensagem;
        }

        public EventoServiceResposta(List<Evento> lista, string mensagem)
        {
            Lista = lista;
            Erro = false;
            Mensagem = mensagem;
        }
    }
}
