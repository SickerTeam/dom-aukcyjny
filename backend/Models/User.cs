﻿namespace backend.Models
{
    public class User
    {
        // All firlds including Id & Password
        public User(int id, string email, string password, string firstName, string lastName, string bio, string country, string link, UserRole role)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Bio = bio;
            this.Country = country;
            this.Link = link;
            this.Role = role;
        }

        private int Id { get; set; }
        private string Email {  get; set; }
        private string Password { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Bio {  get; set; }
        private string Country { get; set; }
        private string Link { get; set; }
        private UserRole Role { get; set; }
    }
}