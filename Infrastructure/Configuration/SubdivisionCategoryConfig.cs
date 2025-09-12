using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class SubdivisionCategoryConfiguration : IEntityTypeConfiguration<SubdivisionCategory>
{
    public void Configure(EntityTypeBuilder<SubdivisionCategory> builder)
    {
        // Tabla
        builder.ToTable("subdivision_categories");

        // Clave primaria
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id)
            .HasColumnName("id")
            .HasColumnType("SERIAL")
            .IsRequired();

        builder.Property(sc => sc.Description)
            .HasColumnName("description")
            .HasColumnType("VARCHAR")
            .HasMaxLength(40);
        builder.HasIndex(sc => sc.Description)        
            .IsUnique();

        // Relaciones
        builder.HasMany(sc => sc.StateOrRegions)
            .WithOne(sor => sor.SubdivisionCategory)
            .HasForeignKey(sor => sor.SubdivisionCategoryId);
    }
}