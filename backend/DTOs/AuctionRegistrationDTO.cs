using System.ComponentModel.DataAnnotations;
using backend.Validation;
namespace backend.DTOs

{
    public class AuctionRegistrationDTO
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        [FutureDate(15)]
        public DateTime EndsAt { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double FirstPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double? EstimatedMinimum { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double? EstimatedMaximum { get; set; }

        [Required]
        [MustBeTrue(ErrorMessage = "This field must be true.")]
        public bool IsArchived { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
