using backend.Models;

namespace backend.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        public UserDTO? User { get; set; }

        public string Text { get; set; }

        public DateTime? TimePosted { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

        public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

        public PostDTO(){}

        public PostDTO(int id, UserDTO user, string text, DateTime? timePosted)
        {
            Id = id;
            User = user;
            Text = text;
            TimePosted = timePosted;
        }

        public PostDTO(int id, UserDTO user, string text, DateTime? timePosted, ICollection<Comment> comments, ICollection<Like> likes, ICollection<Picture> pictures)
        {
            Id = id;
            User = user;
            Text = text;
            TimePosted = timePosted;
            Comments = comments;
            Likes = likes;
            Pictures = pictures;
        }
    }
}
