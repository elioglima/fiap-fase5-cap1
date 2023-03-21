using System.Text.Json.Serialization;
using Greenlight.Entitys;

namespace Greenlight.Models
{
    public class PessoaJuridicaServiceRequisicao : Pessoa
    {

        [JsonIgnore]
        public new PessoaFisica? PessoaFisica { get; set; }


    }
}
