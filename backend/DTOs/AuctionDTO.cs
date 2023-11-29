using backend.Models;

namespace backend.DTOs
{
    public class AuctionDTO
    {
        public AuctionDTO() { }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndsAt { get; set; }
        public float FirstPrice { get; set; }
        public float? EstimatedMinimum { get; set; }
        public float? EstimatedMaximum { get; set; }
        public bool IsArchived { get; set; }
        public Product? Product { get; set; }

    }
}
