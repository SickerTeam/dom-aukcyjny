#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class PictureCreationDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [Url]
        [StringLength(1023, ErrorMessage = "Text cannot exceed 1023 characters.")]
        public string Link { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}
