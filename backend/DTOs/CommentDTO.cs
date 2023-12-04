using backend.Models;

namespace backend.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public int? PostId { get; set; }

        public string Text { get; set; }

        public DateTime? TimePosted { get; set; }
        
        public int? UserId { get; set; }


        public CommentDTO(){}

        public CommentDTO(int id, int? postId, string text, DateTime? timePosted, int? userId)
        {
            Id = id;
            PostId = postId;
            Text = text;
            TimePosted = timePosted;
            UserId = userId;
        }
    }
}
