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
                .ValueGeneratedOnAdd();

            // Propiedades
            builder.Property(b => b.Description)
                .HasColumnName("description")
                .HasMaxLength(80);

            builder.Property(b => b.Detail)
                .HasColumnName("detail");

            builder.Property(b => b.AudienceId)
                .HasColumnName("audience_id");

            // Relaciones
            builder.HasMany(b => b.AudienceBenefits)
                .WithOne(ab => ab.Benefit)
                .HasForeignKey(ab => ab.BenefitId);

            builder.HasMany(b => b.MembershipBenefits)
                .WithOne(mb => mb.Benefit)
                .HasForeignKey(mb => mb.BenefitId);
        }
    }
}
