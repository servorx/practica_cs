using System.Net.Security;

namespace Domain.Entities;

public class Product : BaseEntity<int>
{    public string? Name  { get; set; } = default!;
    public string? Detail { get; set; } = default!;
    public double? Price { get; set; } = default!;
    public int? TypeProductId { get; set; } = default!;
    public string? Image { get; set; } = default!;
    // relaciones 
    public virtual ICollection<CompanyProduct> CompanyProducts { get; set; } = new HashSet<CompanyProduct>();
    public virtual ICollection<DetailFavorite> DetailsFavorites { get; set; } = new HashSet<DetailFavorite>();
    public virtual ICollection<QualityProduct> QualityProducts { get; set; } = new HashSet<QualityProduct>();
    // relacion uno a uno con type_products
    public virtual TypeIdentification TypeIdentification { get; set; } = default!;
    private Product() { } // EF
}