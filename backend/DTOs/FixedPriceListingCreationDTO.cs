using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
   public class FixedPriceListingCreationDTO
    {
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        public ProductCreationDTO Product { get; set; }
    }
}
