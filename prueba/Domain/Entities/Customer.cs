using System.Net.Security;

namespace Domain.Entities;

public class Customer : BaseEntity<int>
{
    public string? Name { get; set; } = default!;
    public string? CityId { get; set; } = default!;
    public int? AudienceId { get; set; } = default!;
    public string? Cellphone { get; set; } = default!;
    public string? Email { get; set; } = default!;
    public string? Address { get; set; } = default!;
    // relaciones 
    public virtual CityOrMunicipality CityOrMunicipality { get; set; } = default!;
    public virtual Audience Audience { get; set; } = default!;
    public virtual ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
    public virtual ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
    public virtual ICollection<QualityProduct> QualityProducts { get; set; } = new HashSet<QualityProduct>();
    private Customer() { } // EF
}