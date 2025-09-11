using System.Net.Security;

namespace Domain.Entities;

public class CityOrMunicipality
{
    public string? Code { get; set; }
    public string? Name { get; set; } = default!;
    public string? StateRegId { get; set; } = default!;
    // relaciones 
    public virtual StateOrRegion StateOrRegion { get; set; } = default!;
    public virtual ICollection<Company> Companies { get; set; } = new HashSet<Company>();
    public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    private CityOrMunicipality() { } // EF
}