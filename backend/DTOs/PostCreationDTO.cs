#nullable disable

using backend.Validation;
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

        [CurrentDateTime(ErrorMessage = "CreatedAt must be within the range of the current time minus 1 minute to the current time.")]
        public DateTime CreatedAt {get; set; }
    }
}
