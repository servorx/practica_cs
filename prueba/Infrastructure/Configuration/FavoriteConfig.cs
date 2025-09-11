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
            .ValueGeneratedOnAdd();

        // Columnas
        builder.Property(f => f.CustomerId)
            .HasColumnName("customer_id")
            .IsRequired();

        builder.Property(f => f.CompanyId)
            .HasColumnName("company_id")
            .HasMaxLength(20)
            .IsRequired();

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
