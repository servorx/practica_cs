using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tabla
            builder.ToTable("categories");

            // Clave primaria
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id");

            // Propiedades
            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasMaxLength(60)
                .IsRequired(false);

            // Relaciones: Category (1) -> (N) Company
            builder.HasMany(c => c.Companies)
                .WithOne(co => co.Category)          // Company.Category (navegación singular)
                .HasForeignKey(co => co.CategoryId)  // FK en Company
                .OnDelete(DeleteBehavior.Cascade);

            // Relaciones: Category (1) -> (N) Product
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)            // Product.Category
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
