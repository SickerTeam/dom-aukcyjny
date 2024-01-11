using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ProductImageDTO(int id, DateTime? createdAt)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; private set; } = id;

        public DateTime? CreatedAt { get; private set; } = createdAt;

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
