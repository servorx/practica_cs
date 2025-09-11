
namespace Domain.Entities;

public class Favorite : BaseEntity<int>
{
    public int? CustomerId { get; set; } = default!;
    public string? CompanyId { get; set; } = default!;
    // relaciones foraneas
    public virtual Customer Customer { get; set; } = default!;
    public virtual Company Company { get; set; } = default!;
    public virtual ICollection<DetailFavorite> DetailsFavorites { get; set; } = new HashSet<DetailFavorite>();
    private Favorite() { } // EF
}