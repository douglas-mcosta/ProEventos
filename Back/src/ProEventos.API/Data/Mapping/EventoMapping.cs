using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.API.Models;

namespace ProEventos.API.Data.Mapping
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Eventos");
        }
    }
}