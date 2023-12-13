using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
   public class FixedPriceListingCreationDTO(int productId, decimal price)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; } = productId;

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; } = price;
    }
}
