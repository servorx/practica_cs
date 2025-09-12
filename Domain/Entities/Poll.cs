
namespace Domain.Entities;

public class Poll : BaseEntity<int>
{
    // public int? Id { get; set; }
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public bool? IsActive { get; set; } = default!;
    public int? CategoryPollId { get; set; } = default!;
    // relaciones foraneas
    public virtual CategoryPoll CategoryPoll { get; set; } = default!;
    public virtual ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
    public virtual ICollection<QualityProduct> QualityProducts { get; set; } = new HashSet<QualityProduct>();
    private Poll() { } // EF
}