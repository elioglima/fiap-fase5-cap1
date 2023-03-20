using System.Text.Json.Serialization;

namespace Greenlight.Entitys
{
    public class PessoaFisica
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? CPF { get; set; }

        public string? RG { get; set; }

        public DateTime? DataNascimento { get; set; }

        [JsonIgnore]
        public Pessoa? Pessoa { get; set; }

    }
}
