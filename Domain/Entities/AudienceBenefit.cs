using System.Net.Security;

namespace Domain.Entities;

public class AudienceBenefit
{
    public int? AudienceId { get; set; } = default!;
    public int? BenefitId { get; set; } = default!;
    // relaciones 
    public virtual Benefit Benefit { get; set; } = default!;
    public virtual Audience Audience { get; set; } = default!;
    private AudienceBenefit() { } // EF
}