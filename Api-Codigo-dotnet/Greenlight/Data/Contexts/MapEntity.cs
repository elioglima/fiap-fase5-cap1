using Greenlight.Data.MapEntity;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Data.Contexts
{
    public static class ResolveMapEntity
    {
        public static void MapEntity(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventoMap());
            builder.ApplyConfiguration(new EventoParticipanteMap());
            builder.ApplyConfiguration(new PessoaFisicaMap());
            builder.ApplyConfiguration(new PessoaJuridicaMap());
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new EnderecoMap());
            builder.ApplyConfiguration(new PessoaMap());
        }
    }
}