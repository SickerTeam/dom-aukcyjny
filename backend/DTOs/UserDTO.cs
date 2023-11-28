using backend.Models;

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
        public string Link { get; set; }
        public UserRole Role { get; set; }

        public UserDTO(int id, string email, string firstName, string lastName, string bio, string country, string link, UserRole role)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            Country = country;
            Link = link;
            Role = role;
        }
    }
}
