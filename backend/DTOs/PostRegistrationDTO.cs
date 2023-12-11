#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
   public class PostRegistrationDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
        public string Text { get; set; }
        public virtual ICollection<PictureRegistrationDTO> Pictures { get; set; } // != null ? new List<PictureDTO>() : [];
    }
}
