#nullable disable

using System.ComponentModel.DataAnnotations;
using backend.Validation;

namespace backend.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<LikeDTO> Likes { get; set; }
        //public virtual ICollection<string> Pictures { get; set; }
    }
}