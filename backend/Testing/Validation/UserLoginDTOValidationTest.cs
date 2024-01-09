using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class UserLoginDTOValidationTest
    {
        private readonly UserLoginDTO _userLoginDTO;

        public UserLoginDTOValidationTest()
        {
            _userLoginDTO = new UserLoginDTO
            {
                Email = "login@login.com",
                KeepLoggedIn = true,
                Password = "Crear text LOL"
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_userLoginDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _userLoginDTO.Email = new string('a', 244) + "@login.com";
            _userLoginDTO.Password = new string('a', 253);
            _userLoginDTO.KeepLoggedIn = true;
            var result = ValidateModel(_userLoginDTO);
            Assert.True(result);
        }     

        [Fact]
        public void Should_Fail_Email_Min()
        {
            _userLoginDTO.Email = "";
            var result = ValidateModel(_userLoginDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Invalid_Email()
        {
            _userLoginDTO.Email = new string('a', 244);
            var result = ValidateModel(_userLoginDTO);
            Assert.False(result);
        }
        
        [Fact]
        public void Should_Fail_Password_Min()
        {
            _userLoginDTO.Password = "";
            var result = ValidateModel(_userLoginDTO);
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