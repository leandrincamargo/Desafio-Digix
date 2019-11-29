using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex.DataModel.Mapping
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(c => c.PessoaId);

            builder.Property(c => c.DominioIdTipo)
                .IsRequired();

            builder.Property(c => c.FamiliaId)
                .IsRequired();

            builder.HasOne(f => f.Familia)
                .WithMany(c => c.Pessoas)
                .HasForeignKey("FamiliaId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.DominioTipo)
                .WithMany(c => c.Pessoas)
                .HasForeignKey("DominioIdTipo")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
