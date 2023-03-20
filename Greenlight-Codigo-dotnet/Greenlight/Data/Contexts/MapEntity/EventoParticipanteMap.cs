using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Greenlight.Entitys;

namespace Greenlight.Data.MapEntity
{
    public class EventoParticipanteMap : IEntityTypeConfiguration<EventoParticipante>
    {
        public void Configure(EntityTypeBuilder<EventoParticipante> builder)
        {

            builder
                .HasIndex(x => x.Id, "IX_File_Energia")
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.HasOne<Evento>(a => a.Evento)
                .WithMany(p => p.EventoParticipante)
                .HasForeignKey(x => x.EventoId);
        }
    }
}