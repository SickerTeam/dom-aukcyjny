namespace backend.Data.Models;

public class DbLike : BaseDbModel
{
    public int PostId { get; set; }

    public virtual DbPost? Post { get; set; }

    public int UserId { get; set; }

    public virtual DbUser? User { get; set; }
}