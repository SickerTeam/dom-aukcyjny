#nullable disable

using System.ComponentModel.DataAnnotations;
using backend.Validation;

namespace backend.DTOs
{
    public class PostDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
        public string Text { get; set; }

        // [CurrentDateTime(ErrorMessage = "CreatedAt must be within the range of the current time minus 1 minute to the current time.")]
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<LikeDTO> Likes { get; set; }
        //public virtual ICollection<string> Pictures { get; set; }
    }
}