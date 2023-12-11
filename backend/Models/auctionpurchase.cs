#nullable disable

namespace backend.Models;

public class AuctionPurchase
{
    public int? Id { get; set; }

    public int SellerId { get; set; }

    public int BuyerId { get; set; }

    public int AuctionId { get; set; }

    public decimal FinalPrice { get; set; }

    public DateTime? PurchasedAt { get; set; }

    public virtual Auction Auction { get; set; }

    public virtual User Buyer { get; set; }

    public virtual User Seller { get; set; }
}