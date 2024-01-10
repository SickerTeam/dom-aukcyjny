using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace Testing.Validation
{
    public class UserDTOValidationTest
    {
        private readonly UserDTO _userDTO;

        public UserDTOValidationTest()
        {
            _userDTO = new UserDTO(1, DateTime.UtcNow)
            {
                Email = "login@login.com",
                FirstName = "FirstName",
                LastName = "LastName",
                Bio = "Bio",
                Country = "Poland",
                PersonalLink = "http://www.google.com",
                ProfilePictureLink = "http://www.google.com",
                Role = UserRole.User
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_userDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            UserDTO _userDTO = new(int.MaxValue, DateTime.UtcNow)
            {
                Email = new string('a', 244) + "@login.com",
                FirstName = "first",
                LastName = "last",
                Bio = new string('a', 2047),
                Country = new string('a', 254),
                PersonalLink = "http://www." + new string('a', 239) + ".com",
                ProfilePictureLink = "http://www." + new string('a', 239) + ".com",
                Role = UserRole.Admin
            };
            Assert.True(ValidateModel(_userDTO));
        }     

        [Fact]
        public void Should_Pass_Email_Min()
        {
            _userDTO.Email = "a@a.a";
            Assert.True(ValidateModel(_userDTO));
        }

        [Fact]
        public void Should_Fail_Email_Min()
        {
            _userDTO.Email = "";
            Assert.False(ValidateModel(_userDTO));
        }

        [Fact]
        public void Should_Fail_Email_Max()
        {
            _userDTO.Email = new string('a', 245) + "@login.com";
            Assert.False(ValidateModel(_userDTO));
        }
        
        [Fact]
        public void Should_Fail_FirstName_Min()
        {
            _userDTO.FirstName = "";
            Assert.False(ValidateModel(_userDTO));
        }   

        [Fact]
        public void Should_Fail_FirstName_Max()
        {
            _userDTO.FirstName = new string('a', 255);
            Assert.False(ValidateModel(_userDTO));
        } 

        [Fact]
        public void Should_Fail_LastName_Min()
        {
            _userDTO.LastName = "";
            Assert.False(ValidateModel(_userDTO));
        }   

        [Fact]
        public void Should_Fail_LastName_Max()
        {
            _userDTO.LastName = new string('a', 255);
            Assert.False(ValidateModel(_userDTO));
        }  

        [Fact]
        public void Should_Fail_Bio_Min()
        {
            _userDTO.Bio = "";
            Assert.False(ValidateModel(_userDTO));
        }   

        [Fact]
        public void Should_Fail_Bio_Max()
        {
            _userDTO.Bio = new string('a', 2048);
            Assert.False(ValidateModel(_userDTO));
        } 

        [Fact]
        public void Should_Fail_Country_Min()
        {
            _userDTO.Country = "";
            Assert.False(ValidateModel(_userDTO));
        }   

        [Fact]
        public void Should_Fail_Country_Max()
        {
            _userDTO.Country = new string('a', 255);
            Assert.False(ValidateModel(_userDTO));
        }     

        [Fact]
        public void Should_Fail_PersonalLink_Min()
        {
            _userDTO.PersonalLink = "http://.m";
            Assert.True(ValidateModel(_userDTO));
        }   

        [Fact]
        public void Should_Fail_PersonalLink_Max()
        {
            _userDTO.PersonalLink = "https:// " + new string('a', 242) + ".com";
            Assert.False(ValidateModel(_userDTO));
        }    

        [Fact]
        public void Should_Fail_ProfilePictureLink_Min()
        {
            _userDTO.ProfilePictureLink = "http://.m";
            Assert.True(ValidateModel(_userDTO));
        }   

        [Fact]
        public void Should_Fail_ProfilePictureLink_Max()
        {
            _userDTO.ProfilePictureLink = "https:// " + new string('a', 242) + ".com";
            Assert.False(ValidateModel(_userDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}