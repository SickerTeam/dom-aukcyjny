using backend.Models;

namespace backend.DTOs
{
    public class InstaBuyDTO(int id, int? productId, decimal? price, bool? isArchived, DateTime? createdAt)
    {
        public int Id { get; set; } = id;
        public int? ProductId { get; set; } = productId;
        public decimal? Price { get; set; } = price;
        public bool? IsArchived { get; set; } = isArchived;
        public DateTime? CreatedAt { get; set; } = createdAt;
    }
}
