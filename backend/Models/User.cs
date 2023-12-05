#nullable disable

namespace backend.Models;

public class User
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Bio { get; set; }

    public string Country { get; set; }

    public string PersonalLink { get; set; }
}