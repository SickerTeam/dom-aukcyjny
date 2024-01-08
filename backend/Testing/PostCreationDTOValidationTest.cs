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
                CreatedAt = DateTime.Now
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_postRegistrationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _postRegistrationDTO.CreatedAt = DateTime.Now.AddSeconds(-1);
            _postRegistrationDTO.UserId = int.MaxValue;
            _postRegistrationDTO.Text = new string('a', 2047);
            var result = ValidateModel(_postRegistrationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _postRegistrationDTO.UserId = 0;
            var result = ValidateModel(_postRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Pass_Text_Min()
        {
            _postRegistrationDTO.Text = "";
            var result = ValidateModel(_postRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Text_Max()
        {
            _postRegistrationDTO.Text = new string('a', 2048);
            var result = ValidateModel(_postRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_CreatedAt_Min()
        {
            _postRegistrationDTO.CreatedAt = DateTime.Now.AddSeconds(-61);
            var result = ValidateModel(_postRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_CreatedAt_Max()
        {
            _postRegistrationDTO.CreatedAt = DateTime.Now.AddSeconds(1);
            var result = ValidateModel(_postRegistrationDTO);
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
