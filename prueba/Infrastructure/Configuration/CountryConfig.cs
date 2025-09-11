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
            .HasMaxLength(10)
            .IsRequired();

        // Columnas
        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.AlsaIsoTwo)
            .HasColumnName("alsa_iso_two")
            .HasMaxLength(2);

        builder.Property(c => c.AlsaIsoThree)
            .HasColumnName("alsa_iso_three")
            .HasMaxLength(3);

        // Relaciones
        builder.HasMany(c => c.StateOrRegions)
            .WithOne(s => s.Country)
            .HasForeignKey(s => s.CountryId);
    }
}
