
namespace Domain.Entities;

public class Rate 
{
    public int? Id { get; set; } = default!;
    public int? CustomerId { get; set; } = default!;
    public int? CompanyId { get; set; } = default!;
    public int? PollId { get; set; } = default!;
    public DateTime? DateRating { get; set; } = default!;
    public double? Rating { get; set; } = default!;

    // relaciones
    public virtual Customer Customer { get; set; } = default!;
    public virtual Company Company { get; set; } = default!;
    public virtual Poll Poll { get; set; } = default!;
    private Rate() { } // EF
}