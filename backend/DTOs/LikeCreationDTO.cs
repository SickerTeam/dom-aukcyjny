using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class LikeCreationDTO
    {       
        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}
