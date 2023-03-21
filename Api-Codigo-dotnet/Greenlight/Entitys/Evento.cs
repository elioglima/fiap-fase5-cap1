using System.Text.Json.Serialization;

namespace Greenlight.Entitys
{
    public class Evento
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Texto { get; set; }

        public DateTime? Data { get; set; }

        public int PessoaId { get; set; }

        [JsonIgnore]
        public Pessoa? Pessoa { get; set; }

        [JsonIgnore]
        public ICollection<EventoParticipante>? EventoParticipante { get; set; }

    }
}
