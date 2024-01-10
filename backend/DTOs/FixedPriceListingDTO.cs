#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class FixedPriceListingDTO(int id, DateTime? createdAt)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; private set; } = id;

        public DateTime? CreatedAt { get; private set; } = createdAt;

        public int ProductId { get; private set; }

        private ProductDTO _product;
        public ProductDTO Product 
        { 
            get => _product; 
            set 
            { 
                _product = value;
                ProductId = _product?.Id ?? default;
            } 
        }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}