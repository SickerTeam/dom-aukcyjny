using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class PostDTO(int id, DateTime? createdAt)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; private set; } = id;

        public DateTime? CreatedAt { get; private set; } = createdAt;

        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
        public required string Text { get; set; }

        public string? ImageLink { get; set; }

        public virtual List<CommentDTO>? Comments { get; set; }
        public virtual List<LikeDTO>? Likes { get; set; }
    }
}