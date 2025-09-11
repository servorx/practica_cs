using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TypeProductConfig : IEntityTypeConfiguration<TypeProduct>
    {
        public void Configure(EntityTypeBuilder<TypeProduct> builder)
        {
            // Tabla
            builder.ToTable("types_products");

            // Clave primaria
            builder.HasKey(tp => tp.Id);
            builder.Property(tp => tp.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER")
                .ValueGeneratedOnAdd();

            // Columnas
            builder.Property(tp => tp.Description)
                .HasColumnName("description")
                .HasMaxLength(80);

            // Relaciones uno a uno
            builder.HasOne(tp => tp.Product)
                .WithOne(p => p.TypeProduct)
                .HasForeignKey<Product>(tp => tp.TypeProductId);
        }
    }
}
