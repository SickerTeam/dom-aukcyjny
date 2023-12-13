namespace backend.Data.Models;

public class DbFixedPriceListingPurchase : BaseDbModel
{
    public int BuyerId { get; set; }

    public int FixedPriceListingId { get; set; }

    public virtual DbUser Buyer { get; set; }

    public virtual DbFixedPriceListing FixedPriceListing { get; set; }
}