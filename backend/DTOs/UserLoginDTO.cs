#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{

    public class UserLoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string Password { get; set; }

        [Required]
        public bool KeepLoggedIn { get; set; }
    }
}