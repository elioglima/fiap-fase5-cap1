using System.Text.Json.Serialization;

namespace Greenlight.Entitys
{
    public class Cliente
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        [JsonIgnore]
        public Pessoa? Pessoa { get; set; }




    }
}
