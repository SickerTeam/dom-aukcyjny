#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class FixedPriceListingDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
