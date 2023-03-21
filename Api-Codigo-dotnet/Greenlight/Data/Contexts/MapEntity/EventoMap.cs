using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Greenlight.Entitys;

namespace Greenlight.Data.MapEntity
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Id, "IX_File_Evento")
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Texto)
                .HasColumnName("texto")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2000)
                .IsRequired();

            builder.HasOne<Pessoa>(a => a.Pessoa)
                .WithMany(p => p.Evento)
                .HasForeignKey(x => x.PessoaId);

        }
    }
}