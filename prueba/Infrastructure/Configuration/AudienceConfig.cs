using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class AudienceConfig : IEntityTypeConfiguration<Audience>
{
    public void Configure(EntityTypeBuilder<Audience> builder)
    {
        builder.ToTable("audiences");

        // Clave primaria
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        // Propiedades
        builder.Property(a => a.Description)
            .HasColumnName("description")
            .HasMaxLength(60);
        // Relaciones
        // muchos a uno
        builder.HasMany(a => a.AudienceBenefits)
            .WithOne(ab => ab.Audience)
            .HasForeignKey(ab => ab.AudienceId);

        builder.HasMany(a => a.Companies)
            .WithOne(c => c.Audience)
            .HasForeignKey(c => c.AudienceId);

        builder.HasMany(a => a.Customers)
            .WithOne(cu => cu.Audience)
            .HasForeignKey(cu => cu.AudienceId);
    }
}