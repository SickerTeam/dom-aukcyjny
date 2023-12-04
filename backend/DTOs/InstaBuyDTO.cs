using backend.Models;

namespace backend.DTOs
{
    public class InstaBuyDTO(int id, ProductDTO product, decimal price, bool isArchived, DateTime? createdAt)
    {
        public int? Id { get; set; } = id;
        public ProductDTO Product { get; set; } = product;
        public decimal Price { get; set; } = price;
        public bool IsArchived { get; set; } = isArchived;
        public DateTime? CreatedAt { get; set; } = createdAt;
    }
}
