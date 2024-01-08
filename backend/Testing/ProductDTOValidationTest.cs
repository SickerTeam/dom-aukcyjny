using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace Testing.Validation
{
    public class ProductDTOValidationTest
    {
        private readonly ProductDTO _productDTO;
        private readonly UserDTO _userDTO;

        public ProductDTOValidationTest()
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
                Id = 1,
                Height = 0.01,
                Width = 0.01,
                Depth = 0.01,
                Weight = 0.01,
                Title = "Owned product",
                Description = "Nice product to own",
                Artist = "Gabriel",
                Year = 0,
                SellerId = 1,
                Seller = _userDTO
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
            _productDTO.Id = int.MaxValue;
            _productDTO.Height = double.MaxValue;
            _productDTO.Width = double.MaxValue;
            _productDTO.Depth = double.MaxValue;
            _productDTO.Weight = double.MaxValue;
            _productDTO.Title = new string('a', 254);
            _productDTO.Description = new string('a', 2047);
            _productDTO.Artist = new string('a', 254);
            _productDTO.Year = 2024;
            _productDTO.SellerId = int.MaxValue;
            var result = ValidateModel(_productDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_Id_Min()
        {
            _productDTO.Id = 0;
            var result = ValidateModel(_productDTO);
            Assert.False(result);
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

        [Fact]
        public void Should_Fail_Year_Min()
        {
            _productDTO.Year = -1;
            var result = ValidateModel(_productDTO);
            Assert.False(result);
        }  

        [Fact]
        public void Should_Fail_Year_Max()
        {
            _productDTO.Year = 2025;
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