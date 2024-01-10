using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class PostDTOValidationTest
    {
        private readonly PostDTO _postDTO;

        public PostDTOValidationTest()
        {
            _postDTO = new PostDTO(1, DateTime.UtcNow)
            {
                UserId = 1,
                Text = "Text",
                Comments = new List<CommentDTO>(),
                Likes = new List<LikeDTO>(),
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_postDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            PostDTO postDTO = new(int.MaxValue, DateTime.UtcNow)
            {
                UserId = int.MaxValue,
                Text = new string('a', 2047),
                Comments = new List<CommentDTO> { new(1, DateTime.UtcNow) },
                Likes = new List<LikeDTO> { new(1, DateTime.UtcNow) }
            };
            Assert.True(ValidateModel(_postDTO));
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _postDTO.UserId = 0;
            Assert.False(ValidateModel(_postDTO));
        }

        [Fact]
        public void Should_Fail_Text_Min()
        {
            _postDTO.Text = "";
            Assert.False(ValidateModel(_postDTO));
        }

        [Fact]
        public void Should_Fail_Text_Max()
        {
            _postDTO.Text = new string('a', 2048);
            Assert.False(ValidateModel(_postDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
