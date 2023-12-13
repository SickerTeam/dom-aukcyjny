using backend.Enums;

namespace backend.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public string Country { get; set; }

        public string PersonalLink { get; set; }

        public string ProfilePictureLink { get; set; }

        public UserRole Role { get; set; }
    }
}
