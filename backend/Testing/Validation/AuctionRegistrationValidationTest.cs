using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class AuctionRegistrationValidationTest
    {
        private readonly AuctionRegistrationDTO _auctionRegistrationDTO;

        public AuctionRegistrationValidationTest()
        {
            _auctionRegistrationDTO = new AuctionRegistrationDTO
            {
                // CreatedAt = DateTime.Now.AddSeconds(-59),
                EndsAt = DateTime.Now.AddSeconds(1),
                FirstPrice = 0.01,
                EstimatedMinimum = 0.01,
                EstimatedMaximum = 0.01,
                // IsArchived = false,
                ProductId = 1
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
            // _auctionRegistrationDTO.CreatedAt = DateTime.Now.AddSeconds(-5);
            _auctionRegistrationDTO.EndsAt = DateTime.Now.AddDays(14);
            _auctionRegistrationDTO.FirstPrice = double.MaxValue;
            _auctionRegistrationDTO.EstimatedMinimum = double.MaxValue;
            _auctionRegistrationDTO.EstimatedMaximum = double.MaxValue;
            _auctionRegistrationDTO.ProductId = int.MaxValue;
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.True(result);
        }

        // [Fact]
        // public void Should_Fail_CreatedAt_Min()
        // {
        //     _auctionRegistrationDTO.CreatedAt = DateTime.Now.AddSeconds(-62);
        //     var result = ValidateModel(_auctionRegistrationDTO);
        //     Assert.False(result);
        // }

        // [Fact]
        // public void Should_Fail_CreatedAt_Max()
        // {
        //     _auctionRegistrationDTO.CreatedAt = DateTime.Now.AddSeconds(2);
        //     var result = ValidateModel(_auctionRegistrationDTO);
        //     Assert.False(result);
        // }

        [Fact]
        public void Should_Fail_FirstPrice_Min()
        {
            _auctionRegistrationDTO.FirstPrice = 0;
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

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _auctionRegistrationDTO.ProductId = 0;
            var result = ValidateModel(_auctionRegistrationDTO);
            Assert.False(result);
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

        // [Fact]
        // public void Should_Validate_IsArchived()
        // {
        //     _auctionRegistrationDTO.IsArchived = true;
        //     var result = ValidateModel(_auctionRegistrationDTO);
        //     Assert.False(result);
        // }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}