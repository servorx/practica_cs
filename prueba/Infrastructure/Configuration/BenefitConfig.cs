using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BenefitConfig : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            // Tabla
            builder.ToTable("benefits");

            // Clave primaria
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id")
                .HasColumnType("SERIAL")
                .IsRequired();

            // Propiedades
            builder.Property(b => b.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(b => b.Detail)
                .HasColumnName("detail")
                .HasColumnType("TEXT");

            // Relaciones
            builder.HasMany(b => b.AudienceBenefits)
                .WithOne(ab => ab.Benefit)
                .HasForeignKey(ab => ab.BenefitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.MembershipBenefits)
                .WithOne(mb => mb.Benefit)
                .HasForeignKey(mb => mb.BenefitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
