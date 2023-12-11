using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.DTOs
{
    public class UserRegistrationDTO
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
        [Required]
        public UserRole Role { get; set; }

        public UserRegistrationDTO() { }

        public UserRegistrationDTO(string email, string firstName, string lastName, string password, string country, UserRole role)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Country = country;
            Role = role;
        }
    }
}