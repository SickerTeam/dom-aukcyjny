using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AuctionDTO(int id, DateTime? createdAt)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; private set; } = id;

        public DateTime? CreatedAt { get; private set; } = createdAt;

        [Required]
        public DateTime EndsAt { get; private set; } = DateTime.UtcNow.AddDays(14);

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimateMinPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimateMaxPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double StartingPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double ReservePrice { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        public int ProductId { get; set; }

        public required ProductDTO Product { get; set; }

        public List<BidDTO>? Bids { get; set; }

        public double CurrentPrice => CalculateCurrentPrice();

        private double CalculateCurrentPrice()
        {
            if (Bids == null || Bids.Count == 0)
            {
                return StartingPrice; // No bids, initial price
            }

            // Find the highest bid amount
            double highestBid = (double)Bids.Max(bid => bid.Amount);
            return highestBid;
        }
    }
}
