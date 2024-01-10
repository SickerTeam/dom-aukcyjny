using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class FixedPriceListingCreationDTOValidationTest
    {
        private readonly FixedPriceListingCreationDTO _instaBuyRegistrationDTO;
        private readonly ProductCreationDTO _productCreationDTO;

        public FixedPriceListingCreationDTOValidationTest()
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

            _instaBuyRegistrationDTO = new FixedPriceListingCreationDTO
            {
                Price = 1.0m,
                Product = _productCreationDTO
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_instaBuyRegistrationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _instaBuyRegistrationDTO.Price = decimal.MaxValue;
            Assert.True(ValidateModel(_instaBuyRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            Assert.False(ValidateModel(_instaBuyRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_Price_Min()
        {
            _instaBuyRegistrationDTO.Price = 0.00m;
            Assert.False(ValidateModel(_instaBuyRegistrationDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}