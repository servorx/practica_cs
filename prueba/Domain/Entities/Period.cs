using System.Net.Security;

namespace Domain.Entities;

public class Period : BaseEntity<int>
{
    public string? Name  { get; set; } = default!;
    // relaciones 
    public virtual ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new HashSet<MembershipPeriod>();
    private Period() { } // EF
}