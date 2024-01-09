using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class FixedPriceListingDTOValidationTest
    {
        private readonly FixedPriceListingDTO _instaBuyDTO;

        public FixedPriceListingDTOValidationTest()
        {
            _instaBuyDTO = new FixedPriceListingDTO
            {
                Id = 1,
                ProductId = 1,
                Price = 0.01m,
                IsArchived = false,
                CreatedAt = null
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_instaBuyDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _instaBuyDTO.Id = int.MaxValue;
            _instaBuyDTO.ProductId = int.MaxValue;
            _instaBuyDTO.Price = decimal.MaxValue;
            _instaBuyDTO.IsArchived = false;
            _instaBuyDTO.CreatedAt = DateTime.Now.AddSeconds(-1);
            var result = ValidateModel(_instaBuyDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_Id_Min()
        {
            _instaBuyDTO.Id = 0;
            var result = ValidateModel(_instaBuyDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _instaBuyDTO.ProductId = 0;
            var result = ValidateModel(_instaBuyDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Price_Min()
        {
            _instaBuyDTO.Price = 0.00m;
            var result = ValidateModel(_instaBuyDTO);
            Assert.False(result);
        }

        // [Fact]
        // public void Should_Fail_CreatedAt_Min()
        // {
        //     _instaBuyDTO.CreatedAt = DateTime.Now.AddSeconds(-61);
        //     var result = ValidateModel(_instaBuyDTO);
        //     Assert.False(result);
        // }

        // [Fact]
        // public void Should_Fail_CreatedAt_Max()
        // {
        //     _instaBuyDTO.CreatedAt = DateTime.Now.AddSeconds(1);
        //     var result = ValidateModel(_instaBuyDTO);
        //     Assert.False(result);
        // }
        
        // [Fact]
        // public void Should_Fail_CreatedAt_Null()
        // {
        //     _instaBuyDTO.CreatedAt = null;
        //     var result = ValidateModel(_instaBuyDTO);
        //     Assert.True(result);
        // }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}