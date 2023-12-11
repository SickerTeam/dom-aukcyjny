#nullable disable

namespace backend.Models;

public class Bid
{
    public int? Id { get; set; }

    public int AuctionId { get; set; }

    public int BidderId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PlacedAt { get; set; }

    public virtual Auction Auction { get; set; }

    public virtual User Bidder { get; set; }
}