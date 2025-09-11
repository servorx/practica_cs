using System.Net.Security;

namespace Domain.Entities;

public class CategoryPoll : BaseEntity<int>
{
    public string? Name { get; set; } = default!;
    // relaciones 
    public virtual ICollection<Poll> Polls { get; set; } = new HashSet<Poll>();
    private CategoryPoll() { } // EF
}