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
            _commentDTO = new CommentDTO
            {
                Id = 1,
                PostId = 1,
                Text = "Test text",
                TimePosted = DateTime.Now,
                UserId = 1
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            _commentDTO.TimePosted = null;
            Assert.True(ValidateModel(_commentDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _commentDTO.Id = int.MaxValue;
            _commentDTO.UserId = int.MaxValue;
            _commentDTO.PostId = int.MaxValue;
            _commentDTO.Text = new string('a', 1023);
            _commentDTO.TimePosted = DateTime.Now;
            Assert.True(ValidateModel(_commentDTO));
        }

        [Fact]
        public void Should_Fail_Id_Min()
        {
            _commentDTO.Id = 0;
            Assert.False(ValidateModel(_commentDTO));
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

        [Fact]
        public void Should_Fail_TimeLikedt_Min()
        {
            _commentDTO.TimePosted = DateTime.Now.AddSeconds(-62);
            Assert.False(ValidateModel(_commentDTO));
        }

        [Fact]
        public void Should_Fail_TimeLikedt_Max()
        {
            _commentDTO.TimePosted = DateTime.Now.AddSeconds(1);
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
