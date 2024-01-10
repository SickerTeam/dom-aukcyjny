namespace backend.DTOs
{
    public class BidDTO
    {
        public AuctionDTO Auction { get; set; }
        public UserDTO User { get; set; }
        public decimal Amount { get; set; }
    }
}