using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Greenlight.Entitys;

namespace Greenlight.Data.MapEntity
{
    public class PessoaFisicaMap : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Id, "IX_File_PessoaFisica")
                .IsUnique();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CPF)
                    .HasColumnName("cpf")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(x => x.RG)
                    .HasColumnName("rg")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(x => x.DataNascimento)
                    .HasColumnName("data_nascimento")
                    .HasColumnType("datetime")
                    .IsRequired();
        }
    }
}