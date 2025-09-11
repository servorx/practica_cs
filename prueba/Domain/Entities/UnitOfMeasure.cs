
namespace Domain.Entities;

public class UnitOfMeasure : BaseEntity<int>
{
    public string? Description { get; set; } = default!;
    // relaciones foraneas
    public virtual ICollection<CompanyProduct> CompanyProducts { get; set; } = new HashSet<CompanyProduct>();
    private UnitOfMeasure() { } // EF
}