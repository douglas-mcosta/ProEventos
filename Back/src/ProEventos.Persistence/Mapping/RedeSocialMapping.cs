using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain;

namespace ProEventos.Persistence.Mapping
{
    public class RedeSocialMapping : IEntityTypeConfiguration<RedeSocial>
    {
        public void Configure(EntityTypeBuilder<RedeSocial> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
            .HasColumnType("varchar(200)");

            builder.Property(x => x.URL)
          .HasColumnType("varchar(200)");

          
            builder.HasOne(x=>x.Palestrante)
            .WithMany(x=>x.RedeSociais)
            .HasForeignKey(x=>x.PalestranteId);

              builder.HasOne(x=>x.Evento)
            .WithMany(x=>x.RedeSociais)
            .HasForeignKey(x=>x.EventoId);
        }
    }
}