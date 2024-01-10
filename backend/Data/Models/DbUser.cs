#nullable disable

using backend.Enums;

namespace backend.Data.Models
{
    public class DbUser : BaseDbModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public string Country { get; set; }

        public string PersonalLink { get; set; }

        public ICollection<DbPicture> ProfilePictureLink { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<DbBid>? Bids { get; set; } = new List<DbBid>();

        public virtual ICollection<DbComment>? Comments { get; set; } = new List<DbComment>();

        public virtual ICollection<DbFixedPriceListingPurchase>? FixedPriceListingPurchases { get; set; } = new List<DbFixedPriceListingPurchase>();

        public virtual ICollection<DbLike>? Likes { get; set; } = new List<DbLike>();

        public virtual ICollection<DbPost>? Posts { get; set; } = new List<DbPost>();

        public virtual ICollection<DbProduct>? Products { get; set; } = new List<DbProduct>();

    }
}
