using System.ComponentModel.DataAnnotations;
using backend.Validation;
namespace backend.DTOs
{
    public class BidDTO
    {
        [Required]
        [Range(1, int.MaxValue)]       
        public int? Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]         
        public int AuctionId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]         
        public int BidderId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [CurrentDateTime(ErrorMessage = "CreatedAt must be within the range of the current time minus 1 minute to the current time.")]
        public DateTime? PlacedAt { get; set; }

        public BidDTO() {}
        public BidDTO(int id, int auctionId, int bidderId, decimal amount, DateTime? placedAt)
        {
            Id = id;
            AuctionId = auctionId;
            BidderId = bidderId;
            Amount = amount;
            PlacedAt = placedAt;
        }
    }
}