using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        // Tabla
        builder.ToTable("rates");

        // Clave primaria compuesta
        builder.HasKey(r => new {r.CustomerId, r.CompanyId, r.PollId });

        // Columnas
        builder.Property(r => r.CustomerId)
            .HasColumnName("customer_id")
            .HasColumnType("INT");

        builder.Property(r => r.CompanyId)
            .HasColumnName("company_id")
            .HasColumnType("VARCHAR");

        builder.Property(r => r.PollId)
            .HasColumnName("poll_id")
            .HasColumnType("INT");

        builder.Property(r => r.DateRating)
            .HasColumnName("daterating")
            .HasColumnType("DATETIME");

        builder.Property(r => r.Rating)
            .HasColumnName("rating")
            .HasColumnType("DOUBLE");

        // Relaciones
        // Rate -> Customer (N:1)
        builder.HasOne(r => r.Customer)
            .WithMany(c => c.Rates) 
            .HasForeignKey(r => r.CustomerId);

        // Rate -> Company (N:1)
        builder.HasOne(r => r.Company)
            .WithMany(c => c.Rates)
            .HasForeignKey(r => r.CompanyId);

        // Rate -> Poll (N:1)
        builder.HasOne(r => r.Poll)
            .WithMany(p => p.Rates)
            .HasForeignKey(r => r.PollId);
    }
}
