namespace backend.Data.Models;

public class DbPicture : BaseDbModel
{
    public int ReferenceId { get; set; }

    public DbProduct? DbProduct { get; set; }

    public required string Link { get; set; }
}