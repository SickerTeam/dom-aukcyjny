using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class AuctionRegistrationValidationTest
    {
        private readonly AuctionCreationDTO _auctionCreationDTO;
        private readonly ProductCreationDTO _productCreationDTO;

        public AuctionRegistrationValidationTest()
        {
            _productCreationDTO = new ProductCreationDTO
            {
                Artist = "Van Gogh",
                Description = "Nice painting",
                Title = "Some flowers",
                Height = 1,
                Width = 1,
                Depth = 1,
                Weight = 1,
                SellerId = 1
            };

            _auctionCreationDTO = new AuctionCreationDTO
            {
                StartingPrice = 0.01,
                EstimatedMinimum = 0.01,
                EstimatedMaximum = 0.01,
                MinimumPrice = 0.01,
                Product = _productCreationDTO
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_auctionCreationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _auctionCreationDTO.StartingPrice = double.MaxValue;
            _auctionCreationDTO.EstimatedMinimum = double.MaxValue;
            _auctionCreationDTO.EstimatedMaximum = double.MaxValue;
            _auctionCreationDTO.MinimumPrice = double.MaxValue;
            Assert.True(ValidateModel(_auctionCreationDTO));
        }

        [Fact]
        public void Should_Fail_StartingPrice_Min()
        {
            _auctionCreationDTO.StartingPrice = 0;
            Assert.False(ValidateModel(_auctionCreationDTO));
        }

        [Fact]
        public void Should_Fail_EstimatedMinimum_Min()
        {
            _auctionCreationDTO.EstimatedMinimum = 0;
            Assert.False(ValidateModel(_auctionCreationDTO));
        }

        [Fact]
        public void Should_Fail_EstimatedMaximum_Min()
        {
            _auctionCreationDTO.EstimatedMaximum = 0;
            Assert.False(ValidateModel(_auctionCreationDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}