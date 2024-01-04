namespace backend.Data.Models;

public class DbFixedPriceListing : BaseDbModel
{
    public int? ProductId { get; set; }

    public decimal Price { get; set; }

    public bool IsArchived { get; set; }

    public virtual ICollection<DbFixedPriceListingPurchase> FixedPriceListingPurchases { get; set; } = new List<DbFixedPriceListingPurchase>();

    public virtual DbProduct Product { get; set; }
}