using Greenlight.Entitys;

namespace Greenlight.Models
{

    public class PessoaServiceResposta
    {
        public Pessoa? Registro;
        public List<Pessoa>? Lista;
        public string Mensagem;
        public bool Erro;

        public PessoaServiceResposta(Pessoa registro, string mensagem)
        {
            Lista = null;
            Registro = registro;
            Mensagem = mensagem;
            Erro = false;
        }

        public PessoaServiceResposta(bool erro, string mensagem)
        {
            Lista = null;
            Registro = null;
            Erro = erro;
            Mensagem = mensagem;
        }

        public PessoaServiceResposta(List<Pessoa> lista, string mensagem)
        {
            Lista = lista;
            Registro = null;
            Mensagem = mensagem;
            Erro = false;
        }
    }
}
