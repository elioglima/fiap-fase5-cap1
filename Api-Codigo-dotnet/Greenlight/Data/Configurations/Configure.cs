using Greenlight.Data.MapEntity;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Data.Configurations.Configure
{
    public static class MapConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventoParticipanteMap());
            builder.ApplyConfiguration(new EventoMap());
            builder.ApplyConfiguration(new ClienteMap());            
            builder.ApplyConfiguration(new PessoaFisicaMap());            
            builder.ApplyConfiguration(new EnderecoMap());
            builder.ApplyConfiguration(new PessoaMap());
        }


    }
}