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
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(80) 
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(255);

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("BOOLEAN") 
            .IsRequired();

        builder.Property(p => p.CategoryPollId)
            .HasColumnName("categorypoll_id")
            .HasColumnType("INT") 
            .IsRequired();

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
