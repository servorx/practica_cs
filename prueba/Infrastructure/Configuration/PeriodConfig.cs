using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PeriodConfiguration : IEntityTypeConfiguration<Period>
{
    public void Configure(EntityTypeBuilder<Period> builder)
    {
        // Nombre de la tabla
        builder.ToTable("periods");

        // Clave primaria
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("SERIAL")
            .IsRequired();

        // Columnas
        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        builder.HasIndex(p => p.Name)
            .IsUnique();

        // Relaciones
        builder.HasMany(p => p.MembershipPeriods)
            .WithOne(mp => mp.Period)
            .HasForeignKey(mp => mp.PeriodId);
    }
}
