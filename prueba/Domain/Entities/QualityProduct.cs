using System.Net.Security;
namespace Domain.Entities;

public class QualityProduct
{
    public int? ProductId { get; set; } = default!;
    public int? CustomerId { get; set; } = default!;
    public int? PollId { get; set; } = default!;
    public string? CompanyId { get; set; } = default!;
    public DateTime? DateRating { get; set; } = default!;
    public double? Rating { get; set; } = default!;
    // relaciones 
    public virtual Company Company { get; set; } = default!;
    public virtual Product Product { get; set; } = default!;
    public virtual Poll Poll { get; set; } = default!;
    public virtual Customer Customer { get; set; } = default!;
    private QualityProduct() { } // EF
}