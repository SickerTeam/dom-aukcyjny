using backend.Enums;

namespace backend.Data.Models
{
    public class DbUser : BaseDbModel
    {
        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Bio { get; set; }

        public required string Country { get; set; }

        public string? PersonalLink { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<DbBid>? Bids { get; set; } = new List<DbBid>();

        public virtual ICollection<DbComment>? Comments { get; set; } = new List<DbComment>();

        public virtual ICollection<DbFixedPriceListingPurchase>? FixedPriceListingPurchases { get; set; } = new List<DbFixedPriceListingPurchase>();

        public virtual ICollection<DbLike>? Likes { get; set; } = new List<DbLike>();

        public virtual ICollection<DbPost>? Posts { get; set; } = new List<DbPost>();

        public virtual ICollection<DbProduct>? Products { get; set; } = new List<DbProduct>();

    }
}
