namespace backend.Data.Models
{
    public class DbAuction : BaseDbModel
    {
        public DateTime EndsAt { get; set; }

        public double EstimatedMinimum { get; set; }

        public double EstimatedMaximum { get; set; }

        public double StartingPrice { get; set; }

        public double MinimumPrice { get; set; }

        public bool IsArchived { get; set; } = false;

        public int ProductId { get; set; }

        public DbProduct Product { get; set; }

        public List<DbBid>? Bids { get; set; }
    }
}
