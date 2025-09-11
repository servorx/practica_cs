using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CompanyProductConfig: IEntityTypeConfiguration<CompanyProduct>
{
    public void Configure(EntityTypeBuilder<CompanyProduct> builder)
    {
        // Tabla
        builder.ToTable("company_products");

        // Clave primaria compuesta
        builder.HasKey(cp => new { cp.CompanyId, cp.ProductId });

        // Columnas
        builder.Property(cp => cp.CompanyId)
            .HasColumnName("company_id")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(cp => cp.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(cp => cp.Price)
            .HasColumnName("price")
            .HasColumnType("double")
            .IsRequired();

        builder.Property(cp => cp.UnitMeasureId)
            .HasColumnName("unit_measure_id")
            .IsRequired();

        // Relaciones
        builder.HasOne(cp => cp.Company)
            .WithMany(c => c.CompanyProducts)
            .HasForeignKey(cp => cp.CompanyId);

        builder.HasOne(cp => cp.Product)
            .WithMany(p => p.CompanyProducts)
            .HasForeignKey(cp => cp.ProductId);

        builder.HasOne(cp => cp.UnitOfMeasure)
            .WithMany(u => u.CompanyProducts)
            .HasForeignKey(cp => cp.UnitMeasureId);
    }
}
