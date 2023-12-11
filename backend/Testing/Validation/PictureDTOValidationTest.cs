using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class PictureDTOValidationTest
    {
        private readonly PictureDTO _pictureDTO;

        public PictureDTOValidationTest()
        {
            _pictureDTO = new PictureDTO
            {
                Id = 1,
                PostId = 1,
                PictureUrl = "https://example.com/picture.jpg"
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_pictureDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _pictureDTO.Id = int.MaxValue;
            _pictureDTO.PostId = int.MaxValue;
            _pictureDTO.PictureUrl = new string('a', 2047);
            Assert.True(ValidateModel(_pictureDTO));
        }

        [Fact]
        public void Should_Fail_Id_Min()
        {
            _pictureDTO.Id = 0;
            Assert.False(ValidateModel(_pictureDTO));
        }

        [Fact]
        public void Should_Fail_PictureUrl_Min()
        {
            _pictureDTO.PictureUrl = "";
            Assert.False(ValidateModel(_pictureDTO));
        }

        [Fact]
        public void Should_Fail_PostId_Min()
        {
            _pictureDTO.PostId = 0;
            Assert.False(ValidateModel(_pictureDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
