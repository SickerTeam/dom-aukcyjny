using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class LikeDTOValidationTest
    {
        private readonly LikeDTO _likeDTO;

        public LikeDTOValidationTest()
        {
            _likeDTO = new LikeDTO(1, DateTime.UtcNow)
            {
                PostId = 1,
                UserId = 1,
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_likeDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            LikeDTO _likeDTO = new(int.MaxValue, DateTime.UtcNow)
            {
                PostId = int.MaxValue,
                UserId = int.MaxValue
            };  
            Assert.True(ValidateModel(_likeDTO));
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _likeDTO.UserId = 0;
            Assert.False(ValidateModel(_likeDTO));
        }

        [Fact]
        public void Should_Fail_PostId_Min()
        {
            _likeDTO.PostId = 0;
            Assert.False(ValidateModel(_likeDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
