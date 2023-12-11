
namespace backend.Models;

public class Post
{
    public int Id { get; set; }

    public User? User { get; set; }

    public string Text { get; set; }

    public DateTime? TimePosted { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like>? Likes { get; set; } = new List<Like>();

    public virtual ICollection<Picture>? Pictures { get; set; } = new List<Picture>();

}