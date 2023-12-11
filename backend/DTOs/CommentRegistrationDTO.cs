using System.ComponentModel.DataAnnotations;
// using backend.Validation;

namespace backend.DTOs
{
    public class CommentRegistrationDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [StringLength(1023, ErrorMessage = "Text cannot exceed 1023 characters.")]
        public string Text { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        public CommentRegistrationDTO(){}

        public CommentRegistrationDTO(int postId, string text, int userId)
        {
            PostId = postId;
            Text = text;
            UserId = userId;
        }
    }
}
