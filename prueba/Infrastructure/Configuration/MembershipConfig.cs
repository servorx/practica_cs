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
            .HasColumnType("SERIAL")
            .IsRequired();

        // Columnas
        builder.Property(m => m.Name)
            .HasColumnName("name")
            .HasMaxLength(50);
        builder.HasIndex(m => m.Name)
            .IsUnique();

        builder.Property(m => m.Description)
            .HasColumnName("description")
            .HasColumnType("TEXT");

        // Relaciones
        builder.HasMany(m => m.MembershipPeriods)
            .WithOne(mp => mp.Membership)
            .HasForeignKey(mp => mp.MembershipId);
    }
}
