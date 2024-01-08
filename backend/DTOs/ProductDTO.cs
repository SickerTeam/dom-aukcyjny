#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class ProductDTO
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public double Height { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public double Width { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public double Depth { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public double Weight { get; set; }

    [Required]
    [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
    public string Title { get; set; }

    [Required]
    [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
    public string Description { get; set; }

    [Required]
    [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
    public string Artist { get; set; }

    [Required]
    [Range(0, 2024)]
    public int Year { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int SellerId { get; set; }

    public UserDTO Seller { get; set; }
}