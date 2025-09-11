using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class StateOrRegionConfig : IEntityTypeConfiguration<StateOrRegion>
    {
        public void Configure(EntityTypeBuilder<StateOrRegion> builder)
        {
            // Tabla
            builder.ToTable("states_or_regions");

            // Clave primaria 
            builder.HasKey(sor => sor.Code);
            builder.Property(sor => sor.Code)
                .HasColumnName("code")
                .HasColumnType("VARCHAR")
                .HasMaxLength(6);

            // Columnas
            builder.Property(sor => sor.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);

            builder.Property(sor => sor.CountryId)
                .HasColumnName("country_id")
                .HasColumnType("VARCHAR")
                .HasMaxLength(6);

            builder.Property(sor => sor.Code3166)
                .HasColumnName("code_3166")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder.Property(sor => sor.SubdivisionCategoryId)
                .HasColumnName("subdivision_category_id")
                .HasColumnType("INT");


            // Relaciones 1:1 con Country
        builder.HasOne(sr => sr.Country)
            .WithMany(c => c.StateOrRegions) // un país tiene muchos estados
            .HasForeignKey(sr => sr.CountryId);

        builder.HasOne(sr => sr.SubdivisionCategory)
            .WithMany(sc => sc.StateOrRegions) // una categoría tiene muchos estados
            .HasForeignKey(sr => sr.SubdivisionCategoryId);

        builder.HasMany(sr => sr.CitiesOrMunicipalities)
            .WithOne(cm => cm.StateOrRegion) // un estado tiene muchas ciudades
            .HasForeignKey(cm => cm.StateRegId);
        }
    }
}
