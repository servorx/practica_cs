using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class CityOrMunicipalityConfig : IEntityTypeConfiguration<CityOrMunicipality>
{
    public void Configure(EntityTypeBuilder<CityOrMunicipality> builder)
    {
        // Tabla
        builder.ToTable("city_or_municipalities");

        // Clave primaria
        builder.HasKey(c => c.Code);
        builder.Property(c => c.Code)
            .HasColumnType("VARCHAR")
            .HasColumnName("code")
            .HasMaxLength(6)
            .IsRequired();

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(60);
        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.Property(c => c.StateRegId)
            .HasColumnName("state_reg_id")
            .HasColumnType("VARCHAR")
            .HasMaxLength(6);

        // Relaciones
        builder.HasOne(c => c.StateOrRegion)
            .WithMany(s => s.CitiesOrMunicipalities)
            .HasForeignKey(c => c.StateRegId);

        builder.HasMany(c => c.Companies)
            .WithOne(co => co.CityOrMunicipality)
            .HasForeignKey(co => co.CityId);
            
        builder.HasMany(c => c.Customers)
            .WithOne(cu => cu.CityOrMunicipality)
            .HasForeignKey(cu => cu.CityId);
    }
}

