#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AuctionDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        [Required]
        public DateTime EndsAt { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimateMinPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimateMaxPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double StartingPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double ReservePrice { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        public ProductDTO Product { get; set; }
    }
}
