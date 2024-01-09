using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class ProductCreationDTOValidationTest
    {
        private readonly ProductCreationDTO _productDTO;

        public ProductCreationDTOValidationTest()
        {
            _productDTO = new ProductCreationDTO
            {
                Height = 0.01,
                Width = 0.01,
                Depth = 0.01,
                Weight = 0.01,
                Title = "Owned product",
                Description = "Nice product to own",
                Artist = "Gabriel",
                Year = 2024,
                SellerId = 1,
            };
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_productDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _productDTO.Height = double.MaxValue;
            _productDTO.Width = double.MaxValue;
            _productDTO.Depth = double.MaxValue;
            _productDTO.Weight = double.MaxValue;
            _productDTO.Title = new string('a', 254);
            _productDTO.Description = new string('a', 2047);
            _productDTO.Artist = new string('a', 254);
            _productDTO.SellerId = int.MaxValue;
            var result = ValidateModel(_productDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_SellerId_Min()
        {
            _productDTO.SellerId = 0;
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Height_Min()
        {
            _productDTO.Height = 0;
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Width_Min()
        {
            _productDTO.Width = 0;
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Depth_Min()
        {
            _productDTO.Depth = 0;
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Weight_Min()
        {
            _productDTO.Weight = 0;
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }     

        [Fact]
        public void Should_Fail_Title_Min()
        {
            _productDTO.Title = "";
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }
        
        [Fact]
        public void Should_Fail_Description_Min()
        {
            _productDTO.Description = "";
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }        

        [Fact]
        public void Should_Fail_Artist_Min()
        {
            _productDTO.Artist = "";
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }                       

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}