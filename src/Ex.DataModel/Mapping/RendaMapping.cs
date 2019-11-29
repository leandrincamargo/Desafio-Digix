using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex.DataModel.Mapping
{
    public class RendaMapping : IEntityTypeConfiguration<Renda>
    {
        public void Configure(EntityTypeBuilder<Renda> builder)
        {
            builder.ToTable("Renda");

            builder.HasKey(c => c.RendaId);

            builder.Property(c => c.PessoaId)
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(14, 2)")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(f => f.Pessoa)
                .WithMany(c => c.Rendas)
                .HasForeignKey("PessoaId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
