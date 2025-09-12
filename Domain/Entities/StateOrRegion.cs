using System.Net.Security;

namespace Domain.Entities;

public class StateOrRegion
{
    public string? Code { get; set; }
    public string? Name { get; set; } = default!;
    public string? CountryId { get; set; } = default!;
    public string? Code3166 { get; set; } = default!;
    public int? SubdivisionCategoryId { get; set; } = default!;
    // relaciones 
    public virtual Country Country { get; set; } = default!;
    public virtual SubdivisionCategory SubdivisionCategory { get; set; } = default!;
    public virtual ICollection<CityOrMunicipality> CitiesOrMunicipalities { get; set; } = new HashSet<CityOrMunicipality>();
    private StateOrRegion() { } // EF
}