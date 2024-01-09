using System.ComponentModel.DataAnnotations;

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

        public DateTime? CreatedAt { get; set; }

        public LikeDTO(){}
    }
}
