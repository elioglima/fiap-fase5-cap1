using Greenlight.Data.MapEntity;
using Microsoft.EntityFrameworkCore;

namespace Greenlight.Data.Contexts
{
    public static class ResolveMapEntity
    {
        public static void MapEntity(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AssociacaoMap());
            builder.ApplyConfiguration(new PessoaFisicaMap());
            builder.ApplyConfiguration(new PessoaJuridicaMap());
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new EnderecoMap());
            builder.ApplyConfiguration(new ConcessionariaMap());
            builder.ApplyConfiguration(new EnergiaMap());
            builder.ApplyConfiguration(new TransacoesMap());
            builder.ApplyConfiguration(new PessoaMap());
            builder.ApplyConfiguration(new AnuncioMap());
        }
    }
}