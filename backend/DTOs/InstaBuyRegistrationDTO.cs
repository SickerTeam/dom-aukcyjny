using backend.Models;

namespace backend.DTOs
{
   public class InstaBuyRegistrationDTO(int productId, decimal price)
    {
        public int ProductId { get; set; } = productId;
        public decimal Price { get; set; } = price;
    }
}
