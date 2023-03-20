using System.Text.Json.Serialization;

namespace Greenlight.Entitys
{
    public class Endereco
    {
        public int Id { get; set; }

        public string CodigoInstalacao { get; set; }
        public string CEP { get; set; }

        public string? Logradouro { get; set; }
        public string Estado { get; set; }

        public string UF { get; set; }

        public string Pais { get; set; }


        public int? Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        

        public int PessoaId { get; set; }

        [JsonIgnore]
        public Pessoa? Pessoa { get; set; }

        [JsonIgnore]
        public ICollection<Energia> Energia { get; set; }

    }
}
