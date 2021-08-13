using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain;

namespace ProEventos.Persistence.Mapping
{
    public class LoteMapping : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Nome)
            .IsRequired()
            .HasColumnType("varchar(30)");

            builder.Property(x=>x.Preco)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

             builder.Property(x=>x.Quantidade)
            .IsRequired();

            builder.ToTable("Lotes");
        }
    }
}