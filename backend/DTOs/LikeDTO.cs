using backend.Models;

namespace backend.DTOs
{
    public class LikeDTO
    {
    public int? Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public DateTime? TimeLiked { get; set; }

        public LikeDTO(){}

        public LikeDTO(int? id, int postId, int userId, DateTime? timeLiked)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            TimeLiked = timeLiked;
        }
    }
}
