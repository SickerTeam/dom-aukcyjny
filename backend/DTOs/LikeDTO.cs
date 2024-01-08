using System.ComponentModel.DataAnnotations;
using backend.Validation;

namespace backend.DTOs
{
    public class LikeDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [CurrentDateTime(ErrorMessage = "CreatedAt must be within the range of the current time minus 1 minute to the current time.")]
        public DateTime? CreatedAt { get; set; }

        public LikeDTO(){}
    }
}
