using Microsoft.EntityFrameworkCore;
using Greenlight.Data.Configurations.Configure;
using Greenlight.Entitys;

namespace Greenlight.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
       

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Evento> Evento { get; set; }

        public DbSet<PessoaFisica> PessoaFisica { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }        

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            MapConfig.Configure(builder);
            base.OnModelCreating(builder);
        }

    }
}
