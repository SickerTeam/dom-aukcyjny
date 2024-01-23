using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ProductImageCreationDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Required]
        [Url]
        [StringLength(1023, ErrorMessage = "Text cannot exceed 1023 characters.")]
        public required string Link { get; set; }
        
        public ProductDTO? Product { get; set; }
    }
}
