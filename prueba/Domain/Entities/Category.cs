using System.Net.Security;

namespace Domain.Entities;

public class Category : BaseEntity<int>
{
    public string? Description { get; set; } = default!;
    public virtual ICollection<Company> Companies { get; set; } = new HashSet<Company>();
}
