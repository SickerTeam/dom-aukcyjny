using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class ProductImageCreationDTOValidationTest
    {
        private readonly ProductImageCreationDTO _productImageCreationDTO;

        public ProductImageCreationDTOValidationTest()
        {
            _productImageCreationDTO = new ProductImageCreationDTO()
            {
                ProductId = 1,
                Link = "http://www.google.com"
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            Assert.True(ValidateModel(_productImageCreationDTO));
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _productImageCreationDTO.ProductId = 2;
            _productImageCreationDTO.Link = "http://www." + new string('a', 1008) + ".com";
            Assert.True(ValidateModel(_productImageCreationDTO));
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _productImageCreationDTO.ProductId = 0;
            Assert.False(ValidateModel(_productImageCreationDTO));
        }

        [Fact]
        public void Should_Fail_Link_Min()
        {
            _productImageCreationDTO.Link = "";
            Assert.False(ValidateModel(_productImageCreationDTO));
        }

        [Fact]
        public void Should_Fail_Link_Max()
        {
            _productImageCreationDTO.Link = new string('a', 1024);
            Assert.False(ValidateModel(_productImageCreationDTO));
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
