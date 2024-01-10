using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class BidCreationDTO
    {
        [Required]
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }
    }
}