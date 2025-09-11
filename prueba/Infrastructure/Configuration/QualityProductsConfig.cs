using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class QualityProductConfig : IEntityTypeConfiguration<QualityProduct>
{
    public void Configure(EntityTypeBuilder<QualityProduct> builder)
    {
        // Tabla
        builder.ToTable("quality_products");

        // Clave primaria compuesta
        builder.HasKey(qp => new {qp.ProductId, qp.CustomerId, qp.PollId, qp.CompanyId });

        // Columnas
        builder.Property(qp => qp.ProductId)
            .HasColumnName("product_id")
            .HasColumnType("INT");

        builder.Property(qp => qp.CustomerId)
            .HasColumnName("customer_id")
            .HasColumnType("INT");

        builder.Property(qp => qp.PollId)
            .HasColumnName("poll_id")
            .HasColumnType("INT");

        builder.Property(qp => qp.CompanyId)
            .HasColumnName("company_id")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);
        
        builder.Property(qp => qp.DateRating)
            .HasColumnName("daterating")
            .HasColumnType("DATETIME");

        builder.Property(qp => qp.Rating)
            .HasColumnName("rating")
            .HasColumnType("DOUBLE");
        // Relaciones
        builder.HasOne(qp => qp.Product)
            .WithMany(p => p.QualityProducts)
            .HasForeignKey(qp => qp.ProductId);

        builder.HasOne(qp => qp.Customer)
            .WithMany(c => c.QualityProducts)
            .HasForeignKey(qp => qp.CustomerId);

        builder.HasOne(qp => qp.Poll)
            .WithMany(p => p.QualityProducts)
            .HasForeignKey(qp => qp.PollId);

        builder.HasOne(qp => qp.Company)
            .WithMany(c => c.QualityProducts)
            .HasForeignKey(qp => qp.CompanyId);
    }
}