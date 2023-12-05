#nullable disable

namespace backend.Models;

public class Auction
{
    public int? Id { get; set; }

    public DateTime? EndsAt { get; set; }

    public decimal? FirstPrice { get; set; }

    public Product Product { get; set; }

    public decimal? EstimatedMinimum { get; set; }

    public decimal? EstimatedMaximum { get; set; }

    public bool? IsArchived { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AuctionPurchase> AuctionPurchases { get; set; } = new List<AuctionPurchase>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
}