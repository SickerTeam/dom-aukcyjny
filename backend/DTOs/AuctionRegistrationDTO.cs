using backend.Models;
using System;

namespace backend.DTOs
{
    public class AuctionRegistrationDTO(DateTime createdAt, DateTime endsAt, double firstPrice,
                  double? estimatedMinimum, double? estimatedMaximum, bool isArchived,
                  ProductDTO product)
    {
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime EndsAt { get; set; } = endsAt;
        public double FirstPrice { get; set; } = firstPrice;
        public double? EstimatedMinimum { get; set; } = estimatedMinimum;
        public double? EstimatedMaximum { get; set; } = estimatedMaximum;
        public bool IsArchived { get; set; } = isArchived;
        public ProductDTO ProductDto { get; set; } = product;
    }
}