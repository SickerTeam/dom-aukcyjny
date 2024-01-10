#nullable disable

namespace backend.Data.Models

{
    public class DbBid : BaseDbModel
    {
        public int AuctionId { get; set; }

        public DbAuction Auction { get; set; }

        public int UserId { get; set; }

        public DbUser User { get; set; }

        public decimal Amount { get; set; }
    }
}
