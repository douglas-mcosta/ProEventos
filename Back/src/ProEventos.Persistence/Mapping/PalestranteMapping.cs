using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain;

namespace ProEventos.Persistence.Mapping
{
    public class PalestranteMapping : IEntityTypeConfiguration<Palestrante>
    {
        public void Configure(EntityTypeBuilder<Palestrante> builder)
        {

            builder.HasKey(x => x.Id);
            
            builder.Property(x=>x.MiniCurriculo)
            .HasColumnType("varchar(500)");

            builder.Property(x=>x.Nome)
            .HasColumnType("varchar(200)");

            builder.Property(x=>x.ImgURL)
            .HasColumnType("varchar(200)");

             builder.Property(x=>x.Email)
            .HasColumnType("varchar(200)");

             builder.Property(x=>x.Telefone)
            .HasColumnType("varchar(9)");

            
             builder.HasMany(e=>e.RedeSociais)
            .WithOne(rs=>rs.Palestrante)
            .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Palestrantes");
        }
    }
}