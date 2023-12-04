using backend.Models;

namespace backend.DTOs
{
    public class UserRegisterationDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }
        public string Link { get; set; }
        public UserRole Role { get; set; }

        public UserRegisterationDTO(){}

        public UserRegisterationDTO(string email, string firstName, string lastName, string password, string bio, string country, string link, UserRole role)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Bio = bio;
            Country = country;
            Link = link;
            Role = role;
        }
    }
}