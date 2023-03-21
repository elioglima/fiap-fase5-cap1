using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Greenlight.Entitys;

namespace Greenlight.Data.MapEntity
{
    public class PessoaJuridicaMap : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {

            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Id, "IX_File_Pessoajuridica")
                .IsUnique();

            builder.Property(x => x.RazaoSocial)
                .HasColumnName("razao_social")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CNPJ)
                    .HasColumnName("cnpj")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(x => x.IE)
                    .HasColumnName("ie")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(x => x.DataAbertura)
                    .HasColumnName("data_abertura")
                    .HasColumnType("datetime")
                    .IsRequired();
        }
    }
}