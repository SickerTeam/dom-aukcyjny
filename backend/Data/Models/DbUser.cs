namespace backend.Data.Models
{
    public class DbUser : BaseDbModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public string Country { get; set; }

        public string PersonalLink { get; set; }
    }
}
