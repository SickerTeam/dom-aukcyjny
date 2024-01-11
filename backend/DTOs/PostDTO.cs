#nullable disable

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
        public string Text { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<LikeDTO> Likes { get; set; }
        public virtual ICollection<ProductImageDTO> ProductImages { get; set; }
    }
}