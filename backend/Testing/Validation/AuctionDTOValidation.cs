using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class AuctionDTOValidationTest
    {
        private readonly AuctionDTO _auctionDTO;

        public AuctionDTOValidationTest()
        {
            _auctionDTO = new AuctionDTO
            {
                Id = 1,
                CreatedAt = DateTime.Now.AddSeconds(-59),
                EndsAt = DateTime.Now.AddSeconds(5),
                FirstPrice = 0.01,
                EstimatedMinimum = 0.01,
                EstimatedMaximum = 0.01,
                ProductId = 1
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_auctionDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _auctionDTO.Id = int.MaxValue;
            _auctionDTO.CreatedAt = DateTime.Now.AddSeconds(-5);
            _auctionDTO.EndsAt = DateTime.Now.AddDays(14);
            _auctionDTO.FirstPrice = double.MaxValue;
            _auctionDTO.EstimatedMinimum = double.MaxValue;
            _auctionDTO.EstimatedMaximum = double.MaxValue;
            _auctionDTO.ProductId = int.MaxValue;
            var result = ValidateModel(_auctionDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_Id_Min()
        {
            _auctionDTO.Id = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_CreatedAt_Min()
        {
            _auctionDTO.CreatedAt = DateTime.Now.AddSeconds(-62);
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_CreatedAt_Max()
        {
            _auctionDTO.CreatedAt = DateTime.Now.AddSeconds(2);
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_FirstPrice_Min()
        {
            _auctionDTO.FirstPrice = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_EstimatedMinimum_Min()
        {
            _auctionDTO.EstimatedMinimum = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_EstimatedMaximum_Min()
        {
            _auctionDTO.EstimatedMaximum = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _auctionDTO.ProductId = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_EndsAt_Min()
        {
            _auctionDTO.EndsAt = DateTime.Now.AddSeconds(-2);
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_EndsAt_Max()
        {
            _auctionDTO.EndsAt = DateTime.Now.AddDays(15).AddMinutes(2);
            Assert.False(ValidateModel(_auctionDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
