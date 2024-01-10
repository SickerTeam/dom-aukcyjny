using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class CommentRegistrationDTOValidationTest
    {
        private readonly CommentCreationDTO _commentRegistrationDTO;

        public CommentRegistrationDTOValidationTest()
        {
            _commentRegistrationDTO = new CommentCreationDTO
            {
                PostId = 1,
                Text = "Test text",
                UserId = 1
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_commentRegistrationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _commentRegistrationDTO.Text = new string('a', 1023);
            _commentRegistrationDTO.UserId = int.MaxValue;
            _commentRegistrationDTO.PostId = int.MaxValue;
            Assert.True(ValidateModel(_commentRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_PostId_Min()
        {
            _commentRegistrationDTO.PostId = 0;
            Assert.False(ValidateModel(_commentRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_Text_Min()
        {
            _commentRegistrationDTO.Text = "";
            Assert.False(ValidateModel(_commentRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_Text_Max()
        {
            _commentRegistrationDTO.Text = new string('a', 1024);
            Assert.False(ValidateModel(_commentRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _commentRegistrationDTO.UserId = 0;
            Assert.False(ValidateModel(_commentRegistrationDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
