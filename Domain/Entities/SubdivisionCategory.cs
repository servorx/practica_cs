
namespace Domain.Entities;

public class SubdivisionCategory : BaseEntity<int>
{
    public string? Description { get; set; } = default!;
    // relaciones foraneas
    public virtual ICollection<StateOrRegion> StateOrRegions { get; set; } = new HashSet<StateOrRegion>();
    private SubdivisionCategory() { } // EF
}