using backend.Models;

namespace backend.DTOs
{
    public class UserDTO
    {
        // User but no password
        public UserDTO(int id, string email, string firstName, string lastName, string bio, string country, string link, UserRole role)
        {
            this.Id = id;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Bio = bio;
            this.Country = country;
            this.Link = link;
            this.Role = role;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }
        public string Link { get; set; }
        public UserRole Role { get; set; }
    }
}
