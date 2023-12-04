using backend.Models;

namespace backend.DTOs
{
    public class PictureDTO
    {
        public int? Id { get; set; }

        public int PostId { get; set; }

        public string PictureUrl { get; set; }

        public PictureDTO(){}

        public PictureDTO(int? id, int postId, string pictureUrl)
        {
            Id = id;
            PostId = postId;
            PictureUrl = pictureUrl;
        }
    }
}
