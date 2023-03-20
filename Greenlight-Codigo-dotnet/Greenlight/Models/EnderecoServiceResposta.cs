using Greenlight.Entitys;

namespace Greenlight.Models
{

    public class EnderecoServiceResposta
    {
        public Endereco? Registro;
        public List<Endereco>? Lista;
        public string Mensagem;
        public bool Erro;

        public EnderecoServiceResposta(Endereco registro, string mensagem)
        {
            Registro = registro;
            Mensagem = mensagem;
            Erro = false;
        }

        public EnderecoServiceResposta(bool erro, string mensagem)
        {
            Registro = null;
            Erro = erro;
            Mensagem = mensagem;
        }

        public EnderecoServiceResposta(List<Endereco> lista, string mensagem)
        {
            Lista = lista;
            Erro = false;
            Mensagem = mensagem;
        }
    }
}
