using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{

    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}