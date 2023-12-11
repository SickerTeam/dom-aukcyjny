namespace backend.Data.Models
{
    public class DbBid : BaseDbModel
    {
        public int AuctionId { get; set; }

        public DbAuction Auction { get; set; }

        public int BidderId { get; set; }

        public DbUser Bidder { get; set; }

        public decimal Amount { get; set; }
    }
}
