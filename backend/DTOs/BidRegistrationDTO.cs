using System.ComponentModel.DataAnnotations;
namespace backend.DTOs
{
    public class BidRegistrationDTO
    {
        [Required]
        [Range(1, int.MaxValue)]         
        public int AuctionId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]         
        public int UserId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        public BidRegistrationDTO() {}
        public BidRegistrationDTO(int auctionId, int userId, decimal amount)
        {
            AuctionId = auctionId;
            UserId = userId;
            Amount = amount;
        }
    }
}