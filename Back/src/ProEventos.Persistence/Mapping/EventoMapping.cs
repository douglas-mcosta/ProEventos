using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain;

namespace ProEventos.Persistence.Mapping
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Tema)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(x=>x.Email)
            .HasColumnType("varchar(255)");

            builder.Property(x=>x.Local)
            .HasColumnType("varchar(255)");

            builder.HasMany(e=>e.RedeSociais)
            .WithOne(rs=>rs.Evento)
            .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Eventos");
        }
    }
}