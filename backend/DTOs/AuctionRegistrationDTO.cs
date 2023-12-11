using System.ComponentModel.DataAnnotations;
using backend.Validation;
namespace backend.DTOs

{
    public class AuctionRegistrationDTO
    {
        // [Required]
        // [CurrentDateTime(ErrorMessage = "CreatedAt must be within the range of the current time minus 1 minute to the current time.")]
        // public DateTime CreatedAt { get; set; }
        
        [Required]
        [FutureDate]
        public DateTime EndsAt { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double FirstPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimatedMinimum { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double EstimatedMaximum { get; set; }

        // [Required]
        // [MustBeFalse(ErrorMessage = "This field must be false.")]
        // public bool IsArchived { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
    }
}
