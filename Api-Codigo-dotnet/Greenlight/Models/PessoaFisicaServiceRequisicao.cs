using System.Text.Json.Serialization;
using Greenlight.Entitys;

namespace Greenlight.Models
{
    public class PessoaFisicaServiceRequisicao : Pessoa
    {

        [JsonIgnore]
        public new PessoaJuridica? PessoaJuridica { get; set; }



    }
}
