namespace backend.Data.Models;

public class DbProductImage : BaseDbModel
{
    public int ProductId { get; set; }

    public DbProduct? Product { get; set; }

    public required string Link { get; set; }
}