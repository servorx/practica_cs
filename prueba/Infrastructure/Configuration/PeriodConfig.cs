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
            .ValueGeneratedOnAdd();

        // Columnas
        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        // Relaciones
        builder.HasMany(p => p.MembershipPeriods)
            .WithOne(mp => mp.Period)
            .HasForeignKey(mp => mp.PeriodId);
    }
}
