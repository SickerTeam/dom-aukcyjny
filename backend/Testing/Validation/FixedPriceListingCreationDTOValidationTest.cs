using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class FixedPriceListingCreationDTOValidationTest
    {
        private readonly FixedPriceListingCreationDTO _instaBuyRegistrationDTO;

        public FixedPriceListingCreationDTOValidationTest()
        {
            _instaBuyRegistrationDTO = new FixedPriceListingCreationDTO(1, 0.01m);
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_instaBuyRegistrationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _instaBuyRegistrationDTO.ProductId = int.MaxValue;
            _instaBuyRegistrationDTO.Price = decimal.MaxValue;
            Assert.True(ValidateModel(_instaBuyRegistrationDTO));
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _instaBuyRegistrationDTO.ProductId = 0;
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