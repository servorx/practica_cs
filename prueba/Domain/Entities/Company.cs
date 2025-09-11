using System.Net.Security;

namespace Domain.Entities;

public class Company : BaseEntity<int>
{
    public int? TypeId { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public int? CategoryId { get; set; } = default!;
    public string? CityId { get; set; } = default!;
    public int? AudienceId { get; set; } = default!;
    public string? Cellphone { get; set; } = default!;
    public string? Email { get; set; } = default!;
    // relaciones 
    public virtual Category Category { get; set; } = default!;
    public virtual CityOrMunicipality CityOrMunicipality { get; set; } = default!;
    public virtual Audience Audience { get; set; } = default!;
    public virtual TypeIdentification TypeIdentification { get; set; } = default!;
    public virtual ICollection<CompanyProduct> CompanyProducts { get; set; } = new HashSet<CompanyProduct>();
    public virtual ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
    public virtual ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
    public virtual ICollection<QualityProduct> QualityProducts { get; set; } = new HashSet<QualityProduct>();
    public virtual ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new HashSet<MembershipPeriod>();
    private Company() { } // EF
}