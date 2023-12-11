using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class PictureRegistrationDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Picture URL cannot exceed 2047 characters.")]
        public string PictureUrl { get; set; }

        public PictureRegistrationDTO(){}

        public PictureRegistrationDTO(int postId, string pictureUrl)
        {
            PictureUrl = pictureUrl;
            PostId = postId;
        }
    }
}
