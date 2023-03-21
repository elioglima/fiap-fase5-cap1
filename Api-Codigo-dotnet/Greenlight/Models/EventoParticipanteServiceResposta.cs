using Greenlight.Entitys;

namespace Greenlight.Models
{

    public class EventoParticipanteServiceResposta
    {
        public EventoParticipante? Registro;
        public List<EventoParticipante>? Lista;
        public string Mensagem;
        public bool Erro;

        public EventoParticipanteServiceResposta(EventoParticipante registro, string mensagem)
        {
            Registro = registro;
            Mensagem = mensagem;
            Erro = false;
        }

        public EventoParticipanteServiceResposta(bool erro, string mensagem)
        {
            Registro = null;
            Erro = erro;
            Mensagem = mensagem;
        }

        public EventoParticipanteServiceResposta(List<EventoParticipante> lista, string mensagem)
        {
            Lista = lista;
            Erro = false;
            Mensagem = mensagem;
        }
    }
}
