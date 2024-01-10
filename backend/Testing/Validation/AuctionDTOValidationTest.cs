using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace Testing.Validation
{
    public class AuctionDTOValidationTest
    {
        private readonly AuctionDTO _auctionDTO;
        private readonly ProductDTO _productDTO;
        private readonly UserDTO _userDTO;

        public AuctionDTOValidationTest()
        {
            _userDTO = new UserDTO(1, DateTime.UtcNow)
            {
                Bio = "Bardzo fajny seller",
                Email = "seller@gmail.com",
                Country = "Poland",
                FirstName = "First name",
                LastName = "Last name",
                PersonalLink = "www.google.com",
                ProfilePictureLink = "www.google.com",
                Role = UserRole.User
            };

            _productDTO = new ProductDTO(1, DateTime.UtcNow)
            {
                Artist = "Da Vinky?",
                Height = 1,
                Width = 1,
                Depth = 1,
                Weight = 1,
                Description = "Oil painting",
                Seller = _userDTO,
                SellerId = 1,
                Title = "Flowers",
                Year = 1989
            };

            _auctionDTO = new AuctionDTO(1, DateTime.UtcNow)
            {
                ProductId = 1,
                EstimateMaxPrice = 0.01,
                EstimateMinPrice = 0.01,
                ReservePrice = 0.01,
                StartingPrice = 0.01,
                IsArchived = false,
                Product = _productDTO
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            AuctionDTO _auctionDTO = new(1, DateTime.UtcNow)
            {
                ProductId = int.MaxValue,
                Product = _productDTO,
                EstimateMinPrice = int.MaxValue,
                EstimateMaxPrice = int.MaxValue,
                ReservePrice = int.MaxValue,
                StartingPrice = int.MaxValue
            };
            Assert.True(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _auctionDTO.ProductId = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_StartingPrice_Min()
        {
            _auctionDTO.StartingPrice = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_EstimatedMinimum_Min()
        {
            _auctionDTO.EstimateMinPrice = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_EstimatedMaximum_Min()
        {
            _auctionDTO.EstimateMaxPrice = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        [Fact]
        public void Should_Fail_ReservePrice_Min()
        {
            _auctionDTO.ReservePrice = 0;
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
