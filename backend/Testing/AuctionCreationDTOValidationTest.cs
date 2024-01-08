using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class AuctionRegistrationValidationTest
    {
        private readonly AuctionCreationDTO _auctionRegistrationDTO;
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

            _auctionRegistrationDTO = new AuctionCreationDTO
            {
                EndsAt = DateTime.Now.AddSeconds(1),
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
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _auctionRegistrationDTO.EndsAt = DateTime.Now.AddDays(14).AddSeconds(60);
            _auctionRegistrationDTO.StartingPrice = double.MaxValue;
            _auctionRegistrationDTO.EstimatedMinimum = double.MaxValue;
            _auctionRegistrationDTO.EstimatedMaximum = double.MaxValue;
            _auctionRegistrationDTO.MinimumPrice = double.MaxValue;
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Validate_EndsAt_Max()
        {
            _auctionRegistrationDTO.EndsAt = DateTime.Now.AddDays(14).AddSeconds(61);
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Validate_EndsAt_Min()
        {
            _auctionRegistrationDTO.EndsAt = DateTime.Now.AddSeconds(-1);
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_StartingPrice_Min()
        {
            _auctionRegistrationDTO.StartingPrice = 0;
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_EstimatedMinimum_Min()
        {
            _auctionRegistrationDTO.EstimatedMinimum = 0;
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_EstimatedMaximum_Min()
        {
            _auctionRegistrationDTO.EstimatedMaximum = 0;
            var result = ValidateModel(_auctionRegistrationDTO);
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