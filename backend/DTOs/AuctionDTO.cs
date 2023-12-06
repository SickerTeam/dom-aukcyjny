namespace backend.DTOs
{
    public class AuctionDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndsAt { get; set; }
        public double FirstPrice { get; set; }
        public double? EstimatedMinimum { get; set; }
        public double? EstimatedMaximum { get; set; }
        public bool IsArchived { get; set; }
        public ProductDTO? Product { get; set; }

        public AuctionDTO() {}

        public AuctionDTO(int id, DateTime createdAt, DateTime endsAt, double firstPrice,
                      double? estimatedMinimum, double? estimatedMaximum, bool isArchived,
                      ProductDTO product)
        {
            Id = id;
            CreatedAt = createdAt;
            EndsAt = endsAt;
            FirstPrice = firstPrice;
            EstimatedMinimum = estimatedMinimum;
            EstimatedMaximum = estimatedMaximum;
            IsArchived = isArchived;
            Product = product;
        }
    }
}
