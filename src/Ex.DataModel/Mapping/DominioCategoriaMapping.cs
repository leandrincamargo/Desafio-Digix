using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex.DataModel.Mapping
{
    public class DominioCategoriaMapping : IEntityTypeConfiguration<DominioCategoria>
    {
        public void Configure(EntityTypeBuilder<DominioCategoria> builder)
        {
            builder.ToTable("DominioCategoria");

            builder.HasKey(c => c.DominioCategoriaId);

            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
