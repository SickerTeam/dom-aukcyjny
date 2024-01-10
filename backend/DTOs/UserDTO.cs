#nullable disable

using System.ComponentModel.DataAnnotations;

using backend.Enums;

namespace backend.DTOs
{
    public class UserDTO(int id, DateTime? createdAt)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; private set; } = id;

        public DateTime? CreatedAt { get; private set; } = createdAt;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]        
        public string FirstName { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(2047, ErrorMessage = "Text cannot exceed 2047 characters.")]
        public string Bio { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string Country { get; set; }

        [Required]
        [Url]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string PersonalLink { get; set; }

        [Required]
        [Url]
        [StringLength(254, ErrorMessage = "Text cannot exceed 254 characters.")]
        public string ProfilePictureLink { get; set; }

        [Required]
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }
    }
}
