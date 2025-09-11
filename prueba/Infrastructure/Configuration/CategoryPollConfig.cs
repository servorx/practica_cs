using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CategoryPollConfig : IEntityTypeConfiguration<CategoryPoll>
    {
        public void Configure(EntityTypeBuilder<CategoryPoll> builder)
        {
            // Tabla
            builder.ToTable("category_polls");

            // Clave primaria
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Id)
                .HasColumnName("id")
                .HasColumnType("SERIAL")
                .IsRequired();

            // Propiedades
            builder.Property(cp => cp.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
            builder.HasIndex(cp => cp.Name)
                .IsUnique();

            // Relaciones
            builder.HasMany(cp => cp.Polls)
                .WithOne(p => p.CategoryPoll)
                .HasForeignKey(p => p.CategoryPollId);
        }
    }
}
