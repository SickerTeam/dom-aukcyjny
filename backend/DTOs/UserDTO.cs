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

        private int Id { get; set; }
        private string Email { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Bio { get; set; }
        private string Country { get; set; }
        private string Link { get; set; }
        private UserRole Role { get; set; }
    }
}
