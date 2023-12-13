#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
   public class PostCreationDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
        public string Text { get; set; }
        public DateTime CreatedAt {get; set; }
    }
}
