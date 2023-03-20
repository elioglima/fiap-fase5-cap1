using Greenlight.Data.MapEntity;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Data.Configurations.Configure
{
    public static class MapConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AssociacaoMap());
            builder.ApplyConfiguration(new ClienteMap());            
            builder.ApplyConfiguration(new PessoaFisicaMap());            
            builder.ApplyConfiguration(new EnderecoMap());
            builder.ApplyConfiguration(new PessoaMap());
        }


    }
}