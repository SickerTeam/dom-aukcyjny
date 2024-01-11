namespace backend.DTOs;

public class ProductImageDTO
{
    public int ProductId { get; set; }

    public ProductDTO? Product { get; set; }

    public required string Link { get; set; }
}