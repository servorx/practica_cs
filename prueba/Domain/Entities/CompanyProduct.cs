using System.Net.Security;


namespace Domain.Entities;

public class CompanyProduct
{
    public string? CompanyId { get; set; } = default!;
    public int? ProductId { get; set; } = default!;
    public double? Price { get; set; } = default!;
    public int? UnitMeasureId { get; set; } = default!;
    // relaciones 
    public virtual Company Company { get; set; } = default!;
    public virtual Product Product { get; set; } = default!;
    public virtual UnitOfMeasure UnitOfMeasure { get; set; } = default!;
    private CompanyProduct() { } // EF
}