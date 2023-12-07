#nullable disable

namespace backend.Models;

public class InstaBuyPurchase
{
    public int? Id { get; set; }

    public int UserId { get; set; }

    public int InstaId { get; set; }

    public DateTime PurchasedAt { get; set; }

    public virtual InstaBuy Insta { get; set; }
}