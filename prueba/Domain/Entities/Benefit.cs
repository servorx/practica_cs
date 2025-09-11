using System.Net.Security;

namespace Domain.Entities;

public class Benefit : BaseEntity<int>
{
    public string? Description { get; set; } = default!;
    public string? Detail { get; set; } = default!;
    // relaciones 
    public virtual ICollection<AudienceBenefit> AudienceBenefits { get; set; } = new HashSet<AudienceBenefit>();
    public virtual ICollection<MembershipBenefit> MembershipBenefits { get; set; } = new HashSet<MembershipBenefit>();
    private Benefit() { } // EF
}