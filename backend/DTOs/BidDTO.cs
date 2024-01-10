namespace backend.DTOs
{
    public class BidDTO
    {
        public required AuctionDTO Auction { get; set; }
        public required UserDTO User { get; set; }
        public decimal Amount { get; set; }
    }
}