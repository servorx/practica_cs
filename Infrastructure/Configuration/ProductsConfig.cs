using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Tabla
            builder.ToTable("products");

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
                .HasMaxLength(80);
            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.Property(p => p.Detail)
                .HasColumnName("city_id")
                .HasColumnType("TEXT")
                .HasMaxLength(6);

            builder.Property(p => p.Price)
                .HasColumnName("price")
                .HasColumnType("DOUBLE");

            builder.Property(p => p.TypeProductId)
                .HasColumnName("typeproduct_id")
                .HasColumnType("INT");

            builder.Property(p => p.Image)
                .HasColumnName("image")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // Relaciones
            builder.HasOne(p => p.TypeProduct)
                .WithOne(tp => tp.Product)
                .HasForeignKey<Product>(p => p.TypeProductId);

            builder.HasMany(p => p.CompanyProducts)
                .WithOne(cp => cp.Product)
                .HasForeignKey(cp => cp.ProductId);

            builder.HasMany(p => p.DetailsFavorites)
                .WithOne(df => df.Product)
                .HasForeignKey(df => df.ProductId);

            builder.HasMany(p => p.QualityProducts)
                .WithOne(qp => qp.Product)
                .HasForeignKey(qp => qp.ProductId);
        }
    }
}
