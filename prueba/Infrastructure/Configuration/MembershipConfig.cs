using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        // Nombre de la tabla
        builder.ToTable("memberships");

        // Clave primaria
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Columnas
        builder.Property(m => m.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(m => m.Description)
            .HasColumnName("description")
            .HasMaxLength(255)
            .IsRequired(false);

        // Relaciones
        builder.HasMany(m => m.MembershipPeriods)
            .WithOne(mp => mp.Membership)
            .HasForeignKey(mp => mp.MembershipId);
    }
}
