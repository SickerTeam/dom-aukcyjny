using backend.Models;

namespace backend.DTOs
{
   public class PostDTO(int? id, UserDTO user, string text, DateTime timePosted, ICollection<CommentDTO> comments, ICollection<LikeDTO> likes, ICollection<PictureDTO> pictures)
    {
        public int? Id { get; set; } = id;
        public UserDTO User { get; set; } = user;
        public string Text { get; set; } = text;
        public DateTime TimePosted { get; set; } = timePosted;
        public virtual ICollection<CommentDTO> Comments { get; set; } = comments;
        public virtual ICollection<LikeDTO> Likes { get; set; } = likes;
        public virtual ICollection<PictureDTO> Pictures { get; set; } = pictures; // != null ? new List<PictureDTO>() : [];
    }
}
