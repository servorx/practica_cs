using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Tabla
        builder.ToTable("customers");

        // Clave primaria
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Columnas
        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.CityId)
            .HasColumnName("city_id")
            .IsRequired();

        builder.Property(c => c.AudienceId)
            .HasColumnName("audience_id")
            .IsRequired();

        builder.Property(c => c.Cellphone)
            .HasColumnName("cellphone")
            .HasMaxLength(20);
        builder.HasIndex(c => c.Cellphone).IsUnique();

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasMaxLength(150);
        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.Address)
            .HasColumnName("address")
            .HasMaxLength(200);

        // Relaciones
        builder.HasOne(c => c.CityOrMunicipality)
            .WithMany(cm => cm.Customers)
            .HasForeignKey(c => c.CityId);

        builder.HasOne(c => c.Audience)
            .WithMany(a => a.Customers)
            .HasForeignKey(c => c.AudienceId);

        builder.HasMany(c => c.Favorites)
            .WithOne(f => f.Customer)
            .HasForeignKey(f => f.CustomerId);

        builder.HasMany(c => c.Rates)
            .WithOne(r => r.Customer)
            .HasForeignKey(r => r.CustomerId);

        builder.HasMany(c => c.QualityProducts)
            .WithOne(qp => qp.Customer)
            .HasForeignKey(qp => qp.CustomerId);
    }
}
