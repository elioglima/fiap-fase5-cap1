using Greenlight.Entitys;

namespace Greenlight.Models
{
    public class PessoaFisicaServiceResposta
    {
        public PessoaFisicaServiceRequisicao? Registro;
        public List<PessoaFisica>? Lista;
        public string Mensagem;
        public bool Erro;
        
        public PessoaFisicaServiceResposta(PessoaFisicaServiceRequisicao registro, string mensagem)
        {
            Registro = registro;
            Mensagem = mensagem;
            Erro = false;
        }

        public PessoaFisicaServiceResposta(List<PessoaFisica> lista, string mensagem)
        {
            Lista = lista;
            Registro = null;
            Mensagem = mensagem;
            Erro = false;
        }

        public PessoaFisicaServiceResposta(bool erro, string mensagem)
        {
            Registro = null;
            Erro = erro;
            Mensagem = mensagem;
        }

    }
}
