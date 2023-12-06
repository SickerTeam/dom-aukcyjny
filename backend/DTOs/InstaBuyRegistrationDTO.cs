using backend.Models;

namespace backend.DTOs
{
   public class InstaBuyRegistrationDTO(int productId, decimal? price, bool? isArchived, DateTime? createdAt)
    {
        public int Product { get; set; } = productId;
        public decimal? Price { get; set; } = price;
        public bool? IsArchived { get; set; } = isArchived;
        public DateTime? CreatedAt { get; set; } = createdAt;
    }
}
