using Greenlight.Entitys;

namespace Greenlight.Models
{

    public class ClienteServiceResposta
    {
        public Cliente? Registro;
        public string Token;
        public string Mensagem;
        public bool Erro;

        public ClienteServiceResposta(Cliente registro, string mensagem)
        {
            Registro = registro;
            Mensagem = mensagem;
            Erro = false;
        }

        public ClienteServiceResposta(string token, string mensagem)
        {
            Registro = null;
            Token = token;
            Mensagem = mensagem;
            Erro = false;
        }

        public ClienteServiceResposta(Cliente registro, string token, string mensagem)
        {
            Registro = registro;
            Token = token;
            Mensagem = mensagem;
            Erro = false;
        }

        public ClienteServiceResposta(bool erro, string mensagem)
        {
            Registro = null;
            Erro = erro;
            Mensagem = mensagem;
        }
    }
}
