using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class PostRegistrationDTOValidationTest
    {
        private readonly PostCreationDTO _postRegistrationDTO;

        public PostRegistrationDTOValidationTest()
        {
            _postRegistrationDTO = new PostCreationDTO
            {
                UserId = 1,
                Text = "Sample text",
                ImageLink = "Sample image link"
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_postRegistrationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _postRegistrationDTO.UserId = int.MaxValue;
            _postRegistrationDTO.Text = new string('a', 2047);
            Assert.True(ValidateModel(_postRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _postRegistrationDTO.UserId = 0;
            Assert.False(ValidateModel(_postRegistrationDTO));
        }

        [Fact]
        public void Should_Pass_Text_Min()
        {
            _postRegistrationDTO.Text = "";
            Assert.False(ValidateModel(_postRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_Text_Max()
        {
            _postRegistrationDTO.Text = new string('a', 2048);
            Assert.False(ValidateModel(_postRegistrationDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
