using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Models;
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
            _userDTO = new UserDTO
            {
                Id = 1,
                Bio = "Bardzo fajny seller",
                Email = "seller@gmail.com",
                Country = "Poland",
                FirstName = "First name",
                LastName = "Last name",
                PersonalLink = "www.google.com",
                ProfilePictureLink = "www.google.com",
                Role = UserRole.User
            };

            _productDTO = new ProductDTO
            {
                Artist = "Da Vinky?",
                Height = 1,
                Width = 1,
                Depth = 1,
                Weight = 1,
                Description = "Oil painting",
                Id = 1,
                Seller = _userDTO,
                SellerId = 1,
                Title = "Flowers",
                Year = 1989
            };

            _auctionDTO = new AuctionDTO
            {
                Id = 1,
                ProductId = 1,
                CreatedAt = DateTime.Now.AddSeconds(-59),
                EndsAt = DateTime.Now.AddSeconds(5),
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
            var result = ValidateModel(_auctionDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _auctionDTO.Id = int.MaxValue;
            _auctionDTO.ProductId = int.MaxValue;
            _auctionDTO.CreatedAt = DateTime.Now.AddSeconds(-1);
            _auctionDTO.EndsAt = DateTime.Now.AddDays(14).AddSeconds(60);
            _auctionDTO.EstimateMinPrice = int.MaxValue;
            _auctionDTO.EstimateMaxPrice = int.MaxValue;
            _auctionDTO.ReservePrice = int.MaxValue;
            _auctionDTO.StartingPrice = int.MaxValue;
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
        public void Should_Fail_ProductId_Min()
        {
            _auctionDTO.ProductId = 0;
            Assert.False(ValidateModel(_auctionDTO));
        }

        // [Fact]
        // public void Should_Fail_CreatedAt_Min()
        // {
        //     _auctionDTO.CreatedAt = DateTime.Now.AddSeconds(-61);
        //     Assert.False(ValidateModel(_auctionDTO));
        // }

        // [Fact]
        // public void Should_Fail_CreatedAt_Max()
        // {
        //     _auctionDTO.CreatedAt = DateTime.Now.AddSeconds(1);
        //     Assert.False(ValidateModel(_auctionDTO));
        // }

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
