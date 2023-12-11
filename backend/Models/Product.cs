#nullable disable

namespace backend.Models;

public class Product
{
    public int? Id { get; set; }

    public decimal? Height { get; set; }

    public decimal? Width { get; set; }

    public decimal? Depth { get; set; }

    public decimal? Weight { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public virtual User Artist { get; set; }
}