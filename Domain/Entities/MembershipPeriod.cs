namespace Domain.Entities;

public class MembershipPeriod : BaseEntity<int>
{
    public int? MembershipId { get; set; }
    public int? PeriodId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double? Price { get; set; }
    public string? CompanyId { get; set; } = default!;

    // Relaciones principales
    public virtual Company Company { get; set; } = default!;
    public virtual Membership Membership { get; set; } = default!;
    public virtual Period Period { get; set; } = default!;

    // Relación con membership_benefits
    public virtual ICollection<MembershipBenefit> MembershipBenefits { get; set; } = new HashSet<MembershipBenefit>();
    private MembershipPeriod() { } // EF
}
