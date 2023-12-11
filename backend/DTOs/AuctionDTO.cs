using System.ComponentModel.DataAnnotations;
using backend.Validation;
namespace backend.DTOs
{
    public class AuctionDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public DateTime EndsAt { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double FirstPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimatedMinimum { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimatedMaximum { get; set; }
        public bool IsArchived { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        public AuctionDTO() {}

        public AuctionDTO(int id, DateTime? createdAt, DateTime endsAt, double firstPrice,
                      double estimatedMinimum, double estimatedMaximum, bool isArchived,
                      int productId)
        {
            Id = id;
            CreatedAt = createdAt;
            EndsAt = endsAt;
            FirstPrice = firstPrice;
            EstimatedMinimum = estimatedMinimum;
            EstimatedMaximum = estimatedMaximum;
            IsArchived = isArchived;
            ProductId = productId;
        }
    }
}
