namespace Greenlight.Models
{

    public class InstalarServicesResposta
    {
        public string Mensagem;
        public bool Erro;

        public InstalarServicesResposta(string mensagem)
        {
            Mensagem = mensagem;
            Erro = false;
        }

        public InstalarServicesResposta(bool erro, string mensagem)
        {
            Erro = erro;
            Mensagem = mensagem;
        }

    }
}
