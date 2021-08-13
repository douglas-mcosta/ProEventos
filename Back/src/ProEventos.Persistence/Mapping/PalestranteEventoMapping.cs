using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain;

namespace ProEventos.Persistence.Mapping
{
    public class PalestranteEventoMapping : IEntityTypeConfiguration<PalestranteEvento>
    {
        public void Configure(EntityTypeBuilder<PalestranteEvento> builder)
        {
            builder.HasKey(PE => new {PE.EventoId, PE.PalentranteId});
        }
    }
}