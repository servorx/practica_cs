using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PollConfiguration : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        // Nombre de la tabla
        builder.ToTable("polls");

        // Clave primaria
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("SERIAL")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(80);
        builder.HasIndex(p => p.Name)
            .IsUnique();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("TEXT");

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("BOOLEAN");

        builder.Property(p => p.CategoryPollId)
            .HasColumnName("categorypoll_id")
            .HasColumnType("INT");

        // Relaciones
        builder.HasOne(p => p.CategoryPoll)
            .WithMany(cp => cp.Polls)
            .HasForeignKey(p => p.CategoryPollId);

        builder.HasMany(p => p.Rates)
            .WithOne(r => r.Poll)
            .HasForeignKey(r => r.PollId);

        builder.HasMany(p => p.QualityProducts)
            .WithOne(qp => qp.Poll)
            .HasForeignKey(qp => qp.PollId);
    }
}
