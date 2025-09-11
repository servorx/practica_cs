using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class FavoriteConfig : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        // Tabla
        builder.ToTable("favorites");

        // Clave primaria
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .HasColumnName("id")
            .HasColumnType("SERIAL")
            .IsRequired();

        // Columnas
        builder.Property(f => f.CustomerId)
            .HasColumnName("customer_id")
            .HasColumnType("iNTEGER");

        builder.Property(f => f.CompanyId)
            .HasColumnName("company_id")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        // Relaciones
        builder.HasOne(f => f.Customer)
            .WithMany(c => c.Favorites)
            .HasForeignKey(f => f.CustomerId);

        builder.HasOne(f => f.Company)
            .WithMany(c => c.Favorites)
            .HasForeignKey(f => f.CompanyId);

        builder.HasMany(f => f.DetailsFavorites)
            .WithOne(df => df.Favorite)
            .HasForeignKey(df => df.FavoriteId);
    }
}
