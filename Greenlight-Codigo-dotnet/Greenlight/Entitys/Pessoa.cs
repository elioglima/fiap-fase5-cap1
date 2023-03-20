using System.Text.Json.Serialization;

namespace Greenlight.Entitys
{
    public class Pessoa
    {

        public int Id { get; set; }

        public int AssociacaoId { get; set; }

        public PessoaFisica? PessoaFisica { get; set; }
        public PessoaJuridica? PessoaJuridica { get; set; }


        public int TipoPessoaId { get; set; }


        [JsonIgnore]
        public Cliente? Cliente { get; set; }


        [JsonIgnore]
        public ICollection<Endereco>? Endereco { get; set; }

        [JsonIgnore]
        public ICollection<Evento>? Evento{ get; set; }


    }
}
