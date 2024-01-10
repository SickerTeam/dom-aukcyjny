using System.ComponentModel.DataAnnotations;
using backend.Validation;
namespace backend.DTOs
{
    public class AuctionDTO
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EndsAt { get; set; }

        public double EstimateMinPrice { get; set; }

        public double EstimateMaxPrice { get; set; }

        public double StartingPrice { get; set; }

        public double ReservePrice { get; set; }

        public bool IsArchived { get; set; }

        public int ProductId { get; set; }

        public ProductDTO Product { get; set; }

        public List<BidDTO>? Bids { get; set; }
    }
}
