using backend.Models;

namespace backend.DTOs
{
    public class AuctionDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public float StartingPrice { get; set; }
        public float? EstimatedMinPrice { get; set; }
        public float? EstimatedMaxPrice { get; set; }
        public bool IsArchived { get; set; }
        public Product Product { get; set; }

    }
}
