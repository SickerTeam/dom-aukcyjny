using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class PictureRegistrationDTOValidationTest
    {
        private readonly PictureRegistrationDTO _pictureRegistrationDTO;

        public PictureRegistrationDTOValidationTest()
        {
            _pictureRegistrationDTO = new PictureRegistrationDTO
            {
                PostId = 1,
                PictureUrl = "https://example.com/picture.jpg"
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_pictureRegistrationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _pictureRegistrationDTO.PostId = int.MaxValue;
            _pictureRegistrationDTO.PictureUrl = new string('a', 2047);
            Assert.True(ValidateModel(_pictureRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_PictureUrl_Min()
        {
            _pictureRegistrationDTO.PictureUrl = "";
            Assert.False(ValidateModel(_pictureRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_PostId_Min()
        {
            _pictureRegistrationDTO.PostId = 0;
            Assert.False(ValidateModel(_pictureRegistrationDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
