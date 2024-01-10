namespace backend.Data.Models;

public class DbPicture : BaseDbModel
{
    public int PostId { get; set; }

    public virtual DbPost? Post { get; set; }

    public int UserId { get; set; }

    public virtual DbUser? User { get; set; }

    public required string Link { get; set; }
}