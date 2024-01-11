namespace backend.DTOs
{
    public class BidDTO
    {
        public required int AuctionId { get; set; }
        public required UserDTO User { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}