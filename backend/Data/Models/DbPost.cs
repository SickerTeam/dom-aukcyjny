#nullable disable

namespace backend.Data.Models;

public class DbPost : BaseDbModel
{
    public int UserId { get; set; }

    public string Text { get; set; }

    public virtual DbUser? User { get; set; }

    public virtual ICollection<DbComment>? Comments { get; set; } = new List<DbComment>();

    public virtual ICollection<DbLike>? Likes { get; set; } = new List<DbLike>();

    public virtual ICollection<DbPicture>? Picture { get; set; } = new List<DbPicture>();
}