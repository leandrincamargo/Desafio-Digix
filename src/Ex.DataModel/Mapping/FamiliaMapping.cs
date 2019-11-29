using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex.DataModel.Mapping
{
    public class FamiliaMapping : IEntityTypeConfiguration<Familia>
    {
        public void Configure(EntityTypeBuilder<Familia> builder)
        {
            builder.ToTable("Familia");

            builder.HasKey(c => c.FamiliaId);

            builder.Property(c => c.DominioIdStatus)
                .IsRequired();

            builder.HasOne(f => f.DominioStatus)
                .WithMany(c => c.Familias)
                .HasForeignKey("DominioIdStatus")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
