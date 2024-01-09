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
            _userDTO = new UserDTO
            {
                Id = 1,
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
            var result = ValidateModel(_userDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _userDTO.Id = int.MaxValue;
            _userDTO.Email = new string('a', 244) + "@login.com";
            _userDTO.FirstName = "first";
            _userDTO.LastName = "last";
            _userDTO.Bio = new string('a', 2047);
            _userDTO.Country = new string('a', 254);
            _userDTO.PersonalLink = "http://www." + new string('a', 239) + ".com";
            _userDTO.ProfilePictureLink = "http://www." + new string('a', 239) + ".com";
            _userDTO.Role = UserRole.Admin;
            var result = ValidateModel(_userDTO);
            Assert.True(result);
        }     

        [Fact]
        public void Should_Pass_Id_Min()
        {
            _userDTO.Id = 0;
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Pass_Email_Min()
        {
            _userDTO.Email = "a@a.a";
            var result = ValidateModel(_userDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_Email_Min()
        {
            _userDTO.Email = "";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Email_Max()
        {
            _userDTO.Email = new string('a', 245) + "@login.com";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }
        
        [Fact]
        public void Should_Fail_FirstName_Min()
        {
            _userDTO.FirstName = "";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }   

        [Fact]
        public void Should_Fail_FirstName_Max()
        {
            _userDTO.FirstName = new string('a', 255);
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        } 

        [Fact]
        public void Should_Fail_LastName_Min()
        {
            _userDTO.LastName = "";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }   

        [Fact]
        public void Should_Fail_LastName_Max()
        {
            _userDTO.LastName = new string('a', 255);
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }  

        [Fact]
        public void Should_Fail_Bio_Min()
        {
            _userDTO.Bio = "";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }   

        [Fact]
        public void Should_Fail_Bio_Max()
        {
            _userDTO.Bio = new string('a', 2048);
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        } 

        [Fact]
        public void Should_Fail_Country_Min()
        {
            _userDTO.Country = "";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }   

        [Fact]
        public void Should_Fail_Country_Max()
        {
            _userDTO.Country = new string('a', 255);
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }     

        [Fact]
        public void Should_Fail_PersonalLink_Min()
        {
            _userDTO.PersonalLink = "http://.m";
            var result = ValidateModel(_userDTO);
            Assert.True(result);
        }   

        [Fact]
        public void Should_Fail_PersonalLink_Max()
        {
            _userDTO.PersonalLink = "https:// " + new string('a', 242) + ".com";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }    

        [Fact]
        public void Should_Fail_ProfilePictureLink_Min()
        {
            _userDTO.ProfilePictureLink = "http://.m";
            var result = ValidateModel(_userDTO);
            Assert.True(result);
        }   

        [Fact]
        public void Should_Fail_ProfilePictureLink_Max()
        {
            _userDTO.ProfilePictureLink = "https:// " + new string('a', 242) + ".com";
            var result = ValidateModel(_userDTO);
            Assert.False(result);
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}