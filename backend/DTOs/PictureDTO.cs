using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class PictureDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Picture URL cannot exceed 2000 characters.")]
        public string PictureUrl { get; set; }

        public PictureDTO(){}

        public PictureDTO(int id, int postId, string pictureUrl)
        {
            Id = id;
            PostId = postId;
            PictureUrl = pictureUrl;
        }
    }
}
