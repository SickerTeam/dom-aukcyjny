using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace backend.DTOs
{
    public class UserCreationDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Country { get; set; }
        public UserRole Role { get; set; } = UserRole.User;

        [Required]
        public string PersonalLink { get; set;}

        [Required]
        public string ProfilePictureLink {get; set;}

        [Required]
        public string Bio { get; set; }

    }
}