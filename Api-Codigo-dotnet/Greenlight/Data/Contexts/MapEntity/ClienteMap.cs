using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Greenlight.Entitys;

namespace Greenlight.Data.MapEntity
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Id, "IX_File_Cliente")
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("senha")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}