using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class FixedPriceListingDTOValidationTest
    {
        private readonly FixedPriceListingDTO _listingDto;

        public FixedPriceListingDTOValidationTest()
        {
            _listingDto = new FixedPriceListingDTO(2, DateTime.UtcNow)
            {
                Price = 0.01m,
                IsArchived = false,
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
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, null, true);
        }
    }
}