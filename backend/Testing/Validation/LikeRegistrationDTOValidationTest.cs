using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class LikeRegistrationDTOValidationTest
    {
        private readonly LikeRegistrationDTO _likeRegistrationDTO;

        public LikeRegistrationDTOValidationTest()
        {
            _likeRegistrationDTO = new LikeRegistrationDTO
            {
                PostId = 1,
                UserId = 1
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_likeRegistrationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _likeRegistrationDTO.PostId = int.MaxValue;
            _likeRegistrationDTO.UserId = int.MaxValue;
            Assert.True(ValidateModel(_likeRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_PostId_Min()
        {
            _likeRegistrationDTO.PostId = 0;
            var result = ValidateModel(_likeRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _likeRegistrationDTO.UserId = 0;
            var result = ValidateModel(_likeRegistrationDTO);
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
