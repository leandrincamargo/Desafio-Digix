using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex.DataModel.Mapping
{
    public class DominioMapping : IEntityTypeConfiguration<Dominio>
    {
        public void Configure(EntityTypeBuilder<Dominio> builder)
        {
            builder.ToTable("Dominio");

            builder.HasKey(c => c.DominioId);

            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.DominioCategoriaId)
                .IsRequired();

            builder.HasOne(f => f.DominioCategoria)
                .WithMany(c => c.Dominios)
                .HasForeignKey("DominioCategoriaId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
