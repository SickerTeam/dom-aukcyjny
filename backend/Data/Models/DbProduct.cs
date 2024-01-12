namespace backend.Data.Models
{
    public class DbProduct : BaseDbModel
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        public double Weight { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Artist { get; set; }

        public int? Year { get; set; }

        public int SellerId { get; set; }

        public DbUser? Seller { get; set; }

        public virtual ICollection<DbAuction>? Auctions { get; set; } = new List<DbAuction>();

        public virtual ICollection<DbFixedPriceListing>? FixedPriceListings { get; set; } = new List<DbFixedPriceListing>();

        public virtual ICollection<DbProductImage>? ProductImages { get; set; }
    }
}