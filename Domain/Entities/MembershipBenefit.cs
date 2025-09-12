using System.Net.Security;
namespace Domain.Entities;

public class MembershipBenefit : BaseEntity<int>
{
    public int? MembershipPeriId { get; set; } = default!;
    public int? BenefitId { get; set; } = default!;
    // relaciones 
    public virtual MembershipPeriod MembershipPeriod { get; set; } = default!;
    public virtual Benefit Benefit { get; set; } = default!;
    private MembershipBenefit() { } // EF
}