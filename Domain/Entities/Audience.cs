using System.Net.Security;
namespace Domain.Entities;

public class Audience : BaseEntity<int>
{
    public string? Description { get; set; } = default!;
    // relaciones 
    public virtual ICollection<AudienceBenefit> AudienceBenefits { get; set; } = new HashSet<AudienceBenefit>();
    public virtual ICollection<Company> Companies { get; set; } = new HashSet<Company>();
    public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    private Audience() { } // EF
}