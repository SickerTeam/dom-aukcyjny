#nullable disable

namespace backend.Data.Models;

public class DbComment : BaseDbModel
{
    public int PostId { get; set; }

    public int UserId { get; set; }

    public string Text { get; set; }

    public virtual DbPost Post { get; set; }

    public virtual DbUser User { get; set; }
}