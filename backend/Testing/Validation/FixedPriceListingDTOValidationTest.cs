using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace Testing.Validation
{
    public class FixedPriceListingDTOValidationTest
    {
        private readonly FixedPriceListingDTO _listingDto;
        private readonly ProductDTO _productDTO;
        private readonly UserDTO _userDTO;

        public FixedPriceListingDTOValidationTest()
        {
            _userDTO = new UserDTO(1, DateTime.UtcNow)
            {
                Bio = "Bardzo fajny seller",
                Email = "seller@gmail.com",
                Country = "Poland",
                FirstName = "First name",
                LastName = "Last name",
                PersonalLink = "www.google.com",
                ImageLink = "www.google.com",
                Role = UserRole.User
            };

            _productDTO = new ProductDTO(1, DateTime.UtcNow)
            {
                Height = 0.01,
                Width = 0.01,
                Depth = 0.01,
                Weight = 0.01,
                Title = "Owned product",
                Description = "Nice product to own",
                Artist = "Gabriel",
                Year = 0,
                Seller = _userDTO
            };
            _listingDto = new FixedPriceListingDTO(2, DateTime.UtcNow)
            {
                Price = 0.01m,
                IsArchived = false,
                Product = _productDTO
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_listingDto));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            FixedPriceListingDTO _listingDto = new(int.MaxValue, DateTime.UtcNow)
            {
                Price = decimal.MaxValue,
                IsArchived = false,
            };    
            Assert.True(ValidateModel(_listingDto));
        }

        [Fact]
        public void Should_Fail_Price_Min()
        {
            _listingDto.Price = 0.00m;
            Assert.False(ValidateModel(_listingDto));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}