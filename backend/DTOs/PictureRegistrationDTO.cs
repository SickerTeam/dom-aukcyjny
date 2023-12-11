using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class PictureRegistrationDTO
    {
        [Required]
        [StringLength(2047, ErrorMessage = "Picture URL cannot exceed 2047 characters.")]
        public string PictureUrl { get; set; }

        public PictureRegistrationDTO(){}

        public PictureRegistrationDTO( string pictureUrl)
        {
            PictureUrl = pictureUrl;
        }
    }
}
