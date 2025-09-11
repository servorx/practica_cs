using System;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class PruebaDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<StateOrRegion> StatesOrRegions { get; set; } = default!;
    public DbSet<CityOrMunicipality> CitiesOrMunicipalities { get; set; } = default!;
    public DbSet<SubdivisionCategory> SubdivisionCategories { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Company> Companies { get; set; } = default!;
    public DbSet<TypeIdentification> TypesIdentifications { get; set; } = default!;
    public DbSet<Membership> Memberships { get; set; } = default!;
    public DbSet<Period> Periods { get; set; } = default!;
    public DbSet<MembershipPeriod> MembershipPeriods { get; set; } = default!;
    public DbSet<Benefit> Benefits { get; set; } = default!;
    public DbSet<Audience> Audiences { get; set; } = default!;
    public DbSet<AudienceBenefit> AudienceBenefits { get; set; } = default!;
    public DbSet <MembershipBenefit> MembershipBenefits { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<CompanyProduct> CompanyProducts { get; set; } = default!;
    public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; } = default!;
    public DbSet<Favorite> Favorites { get; set; } = default!;
    public DbSet<DetailFavorite> DetailsFavorites { get; set; } = default!;
    public DbSet<Rate> Rates { get; set; } = default!;
    public DbSet<Poll> Polls { get; set; } = default!;
    public DbSet<CategoryPoll> CategoriesPolls { get; set; } = default!;
    public DbSet<QualityProduct> QualityProducts { get; set; } = default!;
    public DbSet<TypeProduct> TypesProducts { get; set; } = default!;
    public PruebaDbContext(DbContextOptions<PruebaDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}