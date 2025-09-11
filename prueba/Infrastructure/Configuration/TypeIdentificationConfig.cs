using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TypeIdentificationConfig : IEntityTypeConfiguration<TypeIdentification>
    {
        public void Configure(EntityTypeBuilder<TypeIdentification> builder)
        {
            // Tabla
            builder.ToTable("type_identification");

            // Clave primaria 
            builder.HasKey(ti => ti.Id);
            builder.Property(ti => ti.Id)
                .HasColumnName("id")
                .HasColumnType("SERIAL")
                .IsRequired();

            // Columnas
            builder.Property(ti => ti.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);

            builder.Property(ti => ti.Sufix)
                .HasColumnName("sufix")
                .HasColumnType("VARCHAR")
                .HasMaxLength(5);

            // Relaciones
            builder.HasMany(ti => ti.Companies)
                .WithOne(c => c.TypeIdentification)
                .HasForeignKey(ti => ti.TypeId);
        }
    }
}
