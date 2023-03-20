using Greenlight.Entitys;

namespace Greenlight.Models
{
    public class PessoaJuridicaServiceResposta
    {
        public PessoaJuridicaServiceRequisicao? Registro;
        public List<PessoaJuridica>? Lista;
        public string Mensagem;
        public bool Erro;

        public PessoaJuridicaServiceResposta(PessoaJuridicaServiceRequisicao registro, string mensagem)
        {
            Registro = registro;
            Mensagem = mensagem;
            Erro = false;
        }

        public PessoaJuridicaServiceResposta(List<PessoaJuridica> lista, string mensagem)
        {
            Lista = lista;
            Registro = null;
            Mensagem = mensagem;
            Erro = false;
        }

        public PessoaJuridicaServiceResposta(bool erro, string mensagem)
        {
            Registro = null;
            Erro = erro;
            Mensagem = mensagem;
        }
    }
}
