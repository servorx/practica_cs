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
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
            builder.HasIndex(tp => tp.Description)
                .IsUnique();

            // Relación uno a uno con Product
            builder.HasOne(tp => tp.Product)
                .WithOne(p => p.TypeProduct)
                .HasForeignKey<Product>(p => p.TypeProductId); 
        }
    }
}
