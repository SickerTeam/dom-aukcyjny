namespace backend.Models
{
    public class User
    {
        public User(string email, string password, string firstName, string lastName, string bio, string country, string link, UserRole role)
        {
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.bio = bio;
            this.country = country;
            this.link = link;
            this.role = role;
        }

        private string email {  get; set; }
        private string password { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string bio {  get; set; }
        private string country { get; set; }
        private string link { get; set; }
        private UserRole role { get; set; }
    }
}
