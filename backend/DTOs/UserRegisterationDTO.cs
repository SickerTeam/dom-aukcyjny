using backend.Models;

namespace backend.DTOs
{
    public class UserRegisterationDTO
    {
        // user but no ID
        public UserRegisterationDTO(string email, string password, string firstName, string lastName, string bio, string country, string link, UserRole role)
        {
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Bio = bio;
            this.Country = country;
            this.Link = link;
            this.Role = role;
        }
        private string Email { get; set; }
        private string Password { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Bio { get; set; }
        private string Country { get; set; }
        private string Link { get; set; }
        private UserRole Role { get; set; }
    }
}
