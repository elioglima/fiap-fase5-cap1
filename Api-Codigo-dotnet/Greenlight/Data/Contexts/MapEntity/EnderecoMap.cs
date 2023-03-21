using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Greenlight.Entitys;

namespace Greenlight.Data.MapEntity
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Id, "IX_File_Endereco")
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Logradouro)
                .HasColumnName("logradouro")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CEP)
                .HasColumnName("cep")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Numero)
                    .HasColumnName("Numero")
                    .HasColumnType("int")
                    .IsRequired();

            builder.Property(x => x.Complemento)
                .HasColumnName("complemento")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasColumnName("estado")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.UF)
                .HasColumnName("uf")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Pais)
                .HasColumnName("pais")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne<Pessoa>(a => a.Pessoa)
                .WithMany(p => p.Endereco)
                .HasForeignKey(x => x.PessoaId);

        }
    }
}