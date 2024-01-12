using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
   public class ProductImageDTOValidationTest
   {
        private readonly ProductImageDTO _productImageDTO;

        public ProductImageDTOValidationTest()
        {
            _productImageDTO = new ProductImageDTO(1, DateTime.UtcNow)
            {
                ProductId = 1,
                Link = "http://www.google.com"
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_productImageDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _productImageDTO.ProductId = int.MaxValue;
            _productImageDTO.Link = "http://www." + new string('a', 1008) + ".com";
            Assert.True(ValidateModel(_productImageDTO));
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _productImageDTO.ProductId = 0;
            Assert.False(ValidateModel(_productImageDTO));
        }

        [Fact]
        public void Should_Fail_Link_Min()
        {
            _productImageDTO.Link = "";
            Assert.False(ValidateModel(_productImageDTO));
        }

        [Fact]
        public void Should_Fail_Link_Max()
        {
            _productImageDTO.Link = new string('a', 1024);
            Assert.False(ValidateModel(_productImageDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
   }
}