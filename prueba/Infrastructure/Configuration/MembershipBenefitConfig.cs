using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MembershipBenefitConfig : IEntityTypeConfiguration<MembershipBenefit>
{
    public void Configure(EntityTypeBuilder<MembershipBenefit> builder)
    {
        // Tabla
        builder.ToTable("membership_benefits");

        // Clave primaria
        builder.HasKey(mb => mb.Id);

        builder.Property(mb => mb.Id)
            .HasColumnName("id")
            .HasColumnType("INTEGER")
            .ValueGeneratedOnAdd();

        // Columnas
        builder.Property(mb => mb.MembershipPeriId)
            .HasColumnName("membership_period_id")
            .HasColumnType("INTEGER")
            .IsRequired();
        builder.HasIndex(mb => mb.MembershipPeriId)
            .IsUnique();

        builder.Property(mb => mb.BenefitId)
            .HasColumnName("benefit_id")
            .HasColumnType("INTEGER")
            .IsRequired();
        builder.HasIndex(mb => mb.BenefitId)
            .IsUnique();

        // Relaciones
        builder.HasOne(mb => mb.MembershipPeriod)
            .WithMany(mp => mp.MembershipBenefits)
            .HasForeignKey(mb => mb.MembershipPeriId);

        builder.HasOne(mb => mb.Benefit)
            .WithMany(b => b.MembershipBenefits)
            .HasForeignKey(mb => mb.BenefitId);
    }
}
