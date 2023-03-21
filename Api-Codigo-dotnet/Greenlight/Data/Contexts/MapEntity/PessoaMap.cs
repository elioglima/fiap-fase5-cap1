using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Greenlight.Entitys;

namespace Greenlight.Data.MapEntity
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Id, "IX_File_Pessoa")
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.TipoPessoaId)
                    .HasColumnName("tipopessoa")
                    .HasColumnType("int")
                    .IsRequired();

            builder.HasOne<Cliente>(c => c.Cliente)
                 .WithOne(c => c.Pessoa)
                 .HasForeignKey<Cliente>(c => c.Id);

            builder.HasOne<PessoaFisica>(c => c.PessoaFisica)
                        .WithOne(c => c.Pessoa)
                        .HasForeignKey<PessoaFisica>(c => c.Id);

            builder.HasOne<PessoaJuridica>(c => c.PessoaJuridica)
                 .WithOne(c => c.Pessoa)
                 .HasForeignKey<PessoaJuridica>(c => c.Id);

        }
    }
}