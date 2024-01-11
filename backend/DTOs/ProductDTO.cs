#nullable disable

using System.ComponentModel.DataAnnotations;
using backend.Data.Models;

namespace backend.DTOs
{
    public class ProductDTO(int id, DateTime? createdAt)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; private set; } = id;

        public DateTime? CreatedAt { get; private set; } = createdAt;

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

        public virtual ICollection<ProductImageDTO> ProductImages { get; set; }

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
        public int SellerId { get; private set; }

        private UserDTO _seller;
        public UserDTO Seller 
        { 
            get => _seller; 
            set 
            { 
                _seller = value;
                SellerId = _seller?.Id ?? default;
            } 
        }
        
    }
}