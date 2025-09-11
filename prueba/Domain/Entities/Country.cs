using Domain.Entities;

namespace Domain.Entities;

public class Country
{
    public string? Isocode { get; set; }
    public string? Name { get; set; } = default!;
    public string? AlsaIsoTwo { get; set; } = default!;
    public string? AlsaIsoThree { get; set; } = default!;
    // relaciones 
    public virtual ICollection<StateOrRegion> StateOrRegions { get; set; } = new HashSet<StateOrRegion>();
    private Country() { } // EF
}