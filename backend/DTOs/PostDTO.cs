#nullable disable

using System.ComponentModel.DataAnnotations;

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

        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<LikeDTO> Likes { get; set; }
    }
}