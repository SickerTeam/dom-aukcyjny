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
            _postDTO = new PostDTO
            {
                Id = 1,
                UserId = 1,
                Text = "Text",
                CreatedAt = null,
                Comments = new List<CommentDTO>(),
                Likes = new List<LikeDTO>(),
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_postDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _postDTO.Id = int.MaxValue;
            _postDTO.UserId = int.MaxValue;
            _postDTO.Text = new string('a', 2047);
            _postDTO.CreatedAt = DateTime.Now.AddSeconds(-59);
            _postDTO.Comments = new List<CommentDTO> { new() };
            _postDTO.Likes = new List<LikeDTO> { new() };
            var result = ValidateModel(_postDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_Id_Min()
        {
            _postDTO.Id = 0;
            var result = ValidateModel(_postDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _postDTO.UserId = 0;
            var result = ValidateModel(_postDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Text_Min()
        {
            _postDTO.Text = "";
            var result = ValidateModel(_postDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Text_Max()
        {
            _postDTO.Text = new string('a', 2048);
            var result = ValidateModel(_postDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_CreatedAt_Min()
        {
            _postDTO.CreatedAt = DateTime.Now.AddSeconds(1);
            var result = ValidateModel(_postDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_CreatedAt_Max()
        {
            _postDTO.CreatedAt = DateTime.Now.AddSeconds(-61);
            var result = ValidateModel(_postDTO);
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
