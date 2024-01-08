#nullable disable

using System.ComponentModel.DataAnnotations;
using backend.Validation;

namespace backend.DTOs
{
    public class CommentDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [StringLength(1023, ErrorMessage = "Text cannot exceed 1023 characters.")]
        public string Text { get; set; }

        [CurrentDateTime(ErrorMessage = "CreatedAt must be within the range of the current time minus 1 minute to the current time.")]
        public DateTime? CreatedAt { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        public CommentDTO(){}
    }
}
