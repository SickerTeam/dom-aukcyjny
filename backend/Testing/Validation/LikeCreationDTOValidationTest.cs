using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class LikeRegistrationDTOValidationTest
    {
        private readonly LikeCreationDTO _likeRegistrationDTO;

        public LikeRegistrationDTOValidationTest()
        {
            _likeRegistrationDTO = new LikeCreationDTO
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
            Assert.False(ValidateModel(_likeRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_UserId_Min()
        {
            _likeRegistrationDTO.UserId = 0;
            Assert.False(ValidateModel(_likeRegistrationDTO));
        }

        private static bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, null, true);
        }
    }
}
