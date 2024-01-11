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
                Email = "admin@email.com",
                KeepLoggedIn = true,
                Password = "c24799b51c2e3d7263c3c447ec1e8001e6f0b98e9a516f76f9b5e1b6a34166a5"
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_userLoginDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _userLoginDTO.Email = new string('a', 244) + "@login.com";
            _userLoginDTO.Password = new string('a', 253);
            _userLoginDTO.KeepLoggedIn = true;
            Assert.True(ValidateModel(_userLoginDTO));
        }     

        [Fact]
        public void Should_Fail_Email_Min()
        {
            _userLoginDTO.Email = "";
            Assert.False(ValidateModel(_userLoginDTO));
        }

        [Fact]
        public void Should_Fail_Invalid_Email()
        {
            _userLoginDTO.Email = new string('a', 244);
            Assert.False(ValidateModel(_userLoginDTO));
        }
        
        [Fact]
        public void Should_Fail_Password_Min()
        {
            _userLoginDTO.Password = "";
            Assert.False(ValidateModel(_userLoginDTO));
        }                              

        private static bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, null, true);
        }
    }
}