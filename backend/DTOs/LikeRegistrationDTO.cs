using System.ComponentModel.DataAnnotations;
using backend.Validation;

namespace backend.DTOs
{
    public class LikeRegistrationDTO
    {       
        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        public LikeRegistrationDTO(){}

        public LikeRegistrationDTO(int postId, int userId)
        {
            PostId = postId;
            UserId = userId;
        }
    }
}
