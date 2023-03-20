
using System.Text.Json.Serialization;

namespace Greenlight.Entitys
{
    public class EventoParticipante
    {
        public int Id { get; set; }

        public int EventoId { get; set; }

        [JsonIgnore]
        public Evento? Evento { get; set; }

    }
}
