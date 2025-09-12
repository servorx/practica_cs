using System.Net.Security;

namespace Domain.Entities;

public class Membership : BaseEntity<int>
{
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;
    // relaciones 
    public virtual ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new HashSet<MembershipPeriod>();
    private Membership() { } // EF
}