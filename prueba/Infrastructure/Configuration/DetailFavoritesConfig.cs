using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DetailFavoriteConfiguration : IEntityTypeConfiguration<DetailFavorite>
{
    public void Configure(EntityTypeBuilder<DetailFavorite> builder)
    {
        // Tabla
        builder.ToTable("details_favorites");

        // Clave primaria
        builder.HasKey(df => df.Id);

        builder.Property(df => df.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Columnas
        builder.Property(df => df.FavoriteId)
            .HasColumnName("favorite_id")
            .IsRequired();

        builder.Property(df => df.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        // Relaciones
        builder.HasOne(df => df.Favorite)
            .WithMany(f => f.DetailsFavorites)
            .HasForeignKey(df => df.FavoriteId);

        builder.HasOne(df => df.Product)
            .WithMany(p => p.DetailsFavorites)
            .HasForeignKey(df => df.ProductId);
    }
}
