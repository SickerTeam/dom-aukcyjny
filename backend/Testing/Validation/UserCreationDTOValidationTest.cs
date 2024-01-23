using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace Testing.Validation
{
    public class UserCreationDTOValidationTest
    {
        private readonly UserCreationDTO _userCreationDTO;

        public UserCreationDTOValidationTest()
        {
            _userCreationDTO = new UserCreationDTO()
            {
                
                Email = "login@login.com",
                FirstName = "FirstName",
                LastName = "LastName",
                Bio = "Bio",
                Country = "Poland",
                PersonalLink = "http://www.google.com",
                ImageLink = "http://www.google.com",
                Password = "CLEARTEXTBUDDY",
                Role = UserRole.User
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_userCreationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            var samePassword = new string('a', 254);
            _userCreationDTO.Email = new string('a', 244) + "@login.com";
            _userCreationDTO.FirstName = "first";
            _userCreationDTO.LastName = "last";
            _userCreationDTO.Bio = new string('a', 2047);
            _userCreationDTO.Country = new string('a', 254);
            _userCreationDTO.PersonalLink = "http://www." + new string('a', 239) + ".com";
            _userCreationDTO.ImageLink = "http://www." + new string('a', 239) + ".com";
            _userCreationDTO.Password = samePassword;
            _userCreationDTO.Role = UserRole.Admin;
            var result = ValidateModel(_userCreationDTO);
            Assert.True(result);
        }     

        [Fact]
        public void Should_Pass_Email_Min()
        {
            _userCreationDTO.Email = "a@a.a";
            var result = ValidateModel(_userCreationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_Email_Min()
        {
            _userCreationDTO.Email = "";
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Email_Max()
        {
            _userCreationDTO.Email = new string('a', 245) + "@login.com";
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }
        
        [Fact]
        public void Should_Fail_FirstName_Min()
        {
            _userCreationDTO.FirstName = "";
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }   

        [Fact]
        public void Should_Fail_FirstName_Max()
        {
            _userCreationDTO.FirstName = new string('a', 255);
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        } 

        [Fact]
        public void Should_Fail_LastName_Min()
        {
            _userCreationDTO.LastName = "";
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }   

        [Fact]
        public void Should_Fail_LastName_Max()
        {
            _userCreationDTO.LastName = new string('a', 255);
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }  

        [Fact]
        public void Should_Pass_Bio_Min()
        {
            _userCreationDTO.Bio = "";
            var result = ValidateModel(_userCreationDTO);
            Assert.True(result);
        }   

        [Fact]
        public void Should_Fail_Bio_Max()
        {
            _userCreationDTO.Bio = new string('a', 2048);
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        } 

        [Fact]
        public void Should_Fail_Country_Min()
        {
            _userCreationDTO.Country = "";
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }   

        [Fact]
        public void Should_Fail_Country_Max()
        {
            _userCreationDTO.Country = new string('a', 255);
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }     

        [Fact]
        public void Should_Fail_PersonalLink_Min()
        {
            _userCreationDTO.PersonalLink = "http://.m";
            var result = ValidateModel(_userCreationDTO);
            Assert.True(result);
        }   

        [Fact]
        public void Should_Fail_PersonalLink_Max()
        {
            _userCreationDTO.PersonalLink = "https:// " + new string('a', 242) + ".com";
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }    

        [Fact]
        public void Should_Fail_ImageLink_Min()
        {
            _userCreationDTO.ImageLink = "http://.m";
            var result = ValidateModel(_userCreationDTO);
            Assert.True(result);
        }   

        [Fact]
        public void Should_Fail_ImageLink_Max()
        {
            _userCreationDTO.ImageLink = "https:// " + new string('a', 242) + ".com";
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Password_Min()
        {
            var pass = "";
            _userCreationDTO.Password = pass;
            var result = ValidateModel(_userCreationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Password_Max()
        {
            var pass = new string('a', 255);
            _userCreationDTO.Password = pass;
            var result = ValidateModel(_userCreationDTO);
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