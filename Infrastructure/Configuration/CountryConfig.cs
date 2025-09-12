using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Tabla
        builder.ToTable("countries");

        // Clave primaria
        builder.HasKey(c => c.Isocode);
        builder.Property(c => c.Isocode)
            .HasColumnName("isocode")
            .HasColumnType("VARCHAR")
            .HasMaxLength(10)
            .IsRequired();

        // Columnas
        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.Property(c => c.AlsaIsoTwo)
            .HasColumnName("alsa_iso_two")
            .HasMaxLength(2);
        builder.HasIndex(c => c.AlsaIsoTwo)
            .IsUnique();

        builder.Property(c => c.AlsaIsoThree)
            .HasColumnName("alsa_iso_three")
            .HasMaxLength(3);
        builder.HasIndex(c => c.AlsaIsoThree)
            .IsUnique();

        // Relaciones
        builder.HasMany(c => c.StateOrRegions)
            .WithOne(s => s.Country)
            .HasForeignKey(s => s.CountryId);
    }
}
