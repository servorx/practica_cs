using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UnitOfMeasureConfig : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            // Tabla
            builder.ToTable("unit_of_measure");

            // Clave primaria
            builder.HasKey(uof => uof.Id);
            builder.Property(uof => uof.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER")
                .ValueGeneratedOnAdd();

            // Columnas
            builder.Property(uof => uof.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);
            builder.HasIndex(uof => uof.Description)
                .IsUnique();

            // Relaciones
            builder.HasMany(u => u.CompanyProducts)
                .WithOne(cp => cp.UnitOfMeasure)
                .HasForeignKey(cp => cp.UnitMeasureId);
        }
    }
}
