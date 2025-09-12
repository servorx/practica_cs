using System.Net.Security;

namespace Domain.Entities;

public class TypeProduct : BaseEntity<int>
{
    public string? Description { get; set; } = default!;
    // relacion uno a uno con product
    public virtual Product Product { get; set; } = default!;
    private TypeProduct() { } // EF
}