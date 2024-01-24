using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace backend.DTOs
{
    public class UserCreationDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public required string Email { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public required string LastName { get; set; }


        [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
        public string? Bio { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public required string Country { get; set; }

        [Url]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string? PersonalLink { get; set;}

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", 
            ErrorMessage = "Password must be at least 8 characters long and contain at least one letter, one digit, and one special character.")]
        public required string Password { get; set; }

        [Url]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string ImageLink {get; set;}

        [Required]
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; } = UserRole.User;
    }
}