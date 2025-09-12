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
                .HasColumnName("id")
                .HasColumnType("SERIAL")
                .IsRequired();

            // Propiedades
            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);
            builder.HasIndex(c => c.Description)
                .IsUnique();

            // Relaciones uno a muchos
            builder.HasMany(c => c.Companies)
                .WithOne(co => co.Category)         
                .HasForeignKey(co => co.CategoryId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
