#nullable disable

namespace backend.Models;

public class Like
{
    public int Id { get; set; }

    public int? PostId { get; set; }

    public int? UserId { get; set; }

    public DateTime? TimeLiked { get; set; }

}