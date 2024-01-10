#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs

{
    public class AuctionCreationDTO
    {   
        [Required]
        [Range(0.01, double.MaxValue)]
        public double StartingPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double MinimumPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimatedMinimum { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimatedMaximum { get; set; }

        [Required]
        public ProductCreationDTO Product { get; set; }
    }
}
