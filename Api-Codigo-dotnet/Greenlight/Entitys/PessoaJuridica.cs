using System.Text.Json.Serialization;

namespace Greenlight.Entitys
{
    public class PessoaJuridica
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Pessoa? Pessoa { get; set; }

        public string? RazaoSocial { get; set; }

        public string? CNPJ { get; set; }

        public string? IE { get; set; }

        public DateTime? DataAbertura { get; set; }


    }
}
