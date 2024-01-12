using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ProductCreationDTO
    {
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Height { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Width { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Depth { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Weight { get; set; }

        public ICollection<ProductImageCreationDTO>? ProductImages { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public required string Title { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
        public required string Description { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public required string Artist { get; set; }

        [Required]
        [Range(0, 2024)]
        public int Year { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int SellerId { get; set; }
    }
}
