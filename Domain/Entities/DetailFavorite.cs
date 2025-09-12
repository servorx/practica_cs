namespace Domain.Entities;

public class DetailFavorite : BaseEntity<int>
{
    public int? FavoriteId { get; set; } = default!;
    public int? ProductId { get; set; } = default!;
    // relaciones foraneas
    public virtual Product Product { get; set; } = default!;
    public virtual Favorite Favorite { get; set; } = default!;
    private DetailFavorite() { } // EF
}