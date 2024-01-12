using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class CommentDTOValidationTest
    {
        private readonly CommentDTO _commentDTO;

        public CommentDTOValidationTest()
        {
            _commentDTO = new CommentDTO(1, DateTime.UtcNow)
            {
                PostId = 1,
                Text = "Test text",
                UserId = 1
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_commentDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            CommentDTO _commentDTO = new(int.MaxValue, DateTime.UtcNow)
            {
                UserId = int.MaxValue,
                PostId = int.MaxValue,
                Text = new string('a', 1023),
            };
            Assert.True(ValidateModel(_commentDTO));
        }

        [Fact]
        public void Should_Fail_Text_Min()
        {
            _commentDTO.Text = "";
            Assert.False(ValidateModel(_commentDTO));
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _commentDTO.UserId = 0;
            Assert.False(ValidateModel(_commentDTO));
        }

        [Fact]
        public void Should_Fail_PostId_Min()
        {
            _commentDTO.PostId = 0;
            Assert.False(ValidateModel(_commentDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
