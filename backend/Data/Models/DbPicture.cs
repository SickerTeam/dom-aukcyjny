namespace backend.Data.Models;

public class DbPicture : BaseDbModel
{
    public int ReferenceId { get; set; }

    public DbPost? dbPost { get; set; }

    public DbUser? dbUser { get; set; }

    public DbProduct? dbProduct { get; set; }

    public required string Link { get; set; }
}