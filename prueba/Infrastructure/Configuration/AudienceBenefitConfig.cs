using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class AudienceBenefitConfig: IEntityTypeConfiguration<AudienceBenefit>
    {
        public void Configure(EntityTypeBuilder<AudienceBenefit> builder)
        {
            // Tabla
            builder.ToTable("audience_benefits");

            // Clave primaria compuesta
            builder.HasKey(ab => new { ab.AudienceId, ab.BenefitId });

            // Columnas
            builder.Property(ab => ab.AudienceId)
                .HasColumnName("audience_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(ab => ab.BenefitId)
                .HasColumnName("benefit_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            // Relaciones
            builder.HasOne(ab => ab.Audience)
                .WithMany(a => a.AudienceBenefits)
                .HasForeignKey(ab => ab.AudienceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ab => ab.Benefit)
                .WithMany(b => b.AudienceBenefits)
                .HasForeignKey(ab => ab.BenefitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
