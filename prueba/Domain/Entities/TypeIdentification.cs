
namespace Domain.Entities;

public class TypeIdentification : BaseEntity<int>
{
    public string? Description { get; set; } = default!;
    public string? Sufix { get; set; } = default!;
    // relaciones foraneas
    public virtual ICollection<Company> Companies { get; set; } = new HashSet<Company>();
    private TypeIdentification() { } // EF
}