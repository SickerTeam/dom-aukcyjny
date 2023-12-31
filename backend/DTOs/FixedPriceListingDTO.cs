﻿#nullable disable

using System.ComponentModel.DataAnnotations;
using backend.Validation;

namespace backend.DTOs
{
    public class FixedPriceListingDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [MustBeFalse]
        public bool IsArchived { get; set; }

        [CurrentDateTime(ErrorMessage = "CreatedAt must be within the range of the current time minus 1 minute to the current time.")]
        public DateTime? CreatedAt { get; set; }
    }
}
