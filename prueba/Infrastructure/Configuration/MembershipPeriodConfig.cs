using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MembershipPeriodConfiguration : IEntityTypeConfiguration<MembershipPeriod>
{
    public void Configure(EntityTypeBuilder<MembershipPeriod> builder)
    {
        // Tabla
        builder.ToTable("membership_periods");

        // Clave primaria
        builder.HasKey(mp => mp.Id);

        builder.Property(mp => mp.Id)
            .HasColumnName("id")
            .HasColumnType("SERIAL")
            .IsRequired();

        // Columnas
        builder.Property(mp => mp.MembershipId)
            .HasColumnName("membership_id")
            .HasColumnType("INT");

        builder.Property(mp => mp.PeriodId)
            .HasColumnType("INT")
            .HasColumnName("period_id");

        builder.Property(mp => mp.Name)
            .HasColumnName("name")
            .HasMaxLength(80);
        builder.HasIndex(mp => mp.Name)
            .IsUnique();

        builder.Property(mp => mp.Description)
            .HasColumnName("description")
            .HasColumnType("TEXT");

        builder.Property(mp => mp.Price)
            .HasColumnName("price")
            .HasColumnType("DOUBLE");

        builder.Property(mp => mp.CompanyId)
            .HasColumnName("company_id")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        // Relaciones
        builder.HasOne(mp => mp.Company)
            .WithMany(c => c.MembershipPeriods)
            .HasForeignKey(mp => mp.CompanyId);

        builder.HasOne(mp => mp.Membership)
            .WithMany(m => m.MembershipPeriods)
            .HasForeignKey(mp => mp.MembershipId);

        builder.HasOne(mp => mp.Period)
            .WithMany(p => p.MembershipPeriods)
            .HasForeignKey(mp => mp.PeriodId);

        builder.HasMany(mp => mp.MembershipBenefits)
            .WithOne(mb => mb.MembershipPeriod)
            .HasForeignKey(mb => mb.MembershipPeriId);
    }
}
