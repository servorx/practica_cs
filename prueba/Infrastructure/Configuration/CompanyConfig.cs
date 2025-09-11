using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        // Tabla
        builder.ToTable("companies");

        // Clave primaria
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Propiedades
        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(80)
            .IsRequired(true);

        builder.Property(c => c.CategoryId)
            .HasColumnName("category_id")
            .IsRequired(true);

        builder.Property(c => c.CityId)
            .HasColumnName("city_id")
            .IsRequired(true);

        builder.Property(c => c.AudienceId)
            .HasColumnName("audience_id")
            .IsRequired(true);

        builder.Property(c => c.Cellphone)
            .HasColumnName("cellphone")
            .HasMaxLength(15);

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasMaxLength(80)
            .IsRequired(false);

        // Relaciones
        builder.HasOne(c => c.Category)
            .WithMany(co => co.Companies)
            .HasForeignKey(co => co.CategoryId);

        builder.HasOne(c => c.CityOrMunicipality)
            .WithMany(co => co.Companies)
            .HasForeignKey(co => co.CityId);

        builder.HasOne(c => c.Audience)
            .WithMany(a => a.Companies)
            .HasForeignKey(a => a.AudienceId);

        builder.HasMany(c => c.CompanyProducts)
            .WithOne(cp => cp.Company)
            .HasForeignKey(cp => cp.CompanyId);
    }
}