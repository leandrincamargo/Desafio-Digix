using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex.DataModel.Mapping
{
    public class AvaliacaoFamiliarMapping : IEntityTypeConfiguration<AvaliacaoFamiliar>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoFamiliar> builder)
        {
            builder.ToTable("AvaliacaoFamiliar");

            builder.HasKey(c => c.AvaliacaoFamiliarId);

            builder.Property(c => c.FamiliaId)
                .IsRequired();

            builder.HasOne(f => f.Familia)
                .WithMany(c => c.AvaliacoesFamiliar)
                .HasForeignKey("FamiliaId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
