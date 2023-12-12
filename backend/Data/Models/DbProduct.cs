namespace backend.Data.Models
{
    public class DbProduct : BaseDbModel
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        public double Weight { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Artist { get; set; }

        public int SellerId { get; set; }
        public DbUser Seller { get; set; }

        public virtual ICollection<DbAuction> Auctions { get; set; } = new List<DbAuction>();
        public virtual ICollection<DbFixedPriceListing> FixedPriceListings { get; set; } = new List<DbFixedPriceListing>();

    }
}
