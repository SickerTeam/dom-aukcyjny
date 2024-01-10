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
            _userDTO = new UserDTO(1, DateTime.UtcNow)
            {
                Bio = "Bardzo fajny seller",
                Email = "seller@gmail.com",
                Country = "Poland",
                FirstName = "First name",
                LastName = "Last name",
                PersonalLink = "www.google.com",
                ProfilePictureLink = "www.google.com",
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
            ProductDTO _productDTO = new(1, DateTime.UtcNow)
            {
                Height = double.MaxValue,
                Width = double.MaxValue,
                Depth = double.MaxValue,
                Weight = double.MaxValue,
                Title = new string('a', 254),
                Description = new string('a', 2047),
                Artist = new string('a', 254),
                Year = 2024,
                Seller = _userDTO
            };
            var result = ValidateModel(_productDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_Height_Min()
        {
            _productDTO.Height = 0;
            Assert.False(ValidateModel(_productDTO));
        }

        [Fact]
        public void Should_Fail_Width_Min()
        {
            _productDTO.Width = 0;
            Assert.False(ValidateModel(_productDTO));
        }

        [Fact]
        public void Should_Fail_Depth_Min()
        {
            _productDTO.Depth = 0;
            Assert.False(ValidateModel(_productDTO));
        }

        [Fact]
        public void Should_Fail_Weight_Min()
        {
            _productDTO.Weight = 0;
            Assert.False(ValidateModel(_productDTO));
        }     

        [Fact]
        public void Should_Fail_Title_Min()
        {
            _productDTO.Title = "";
            Assert.False(ValidateModel(_productDTO));
        }
        
        [Fact]
        public void Should_Fail_Description_Min()
        {
            _productDTO.Description = "";
            Assert.False(ValidateModel(_productDTO));
        }        

        [Fact]
        public void Should_Fail_Artist_Min()
        {
            _productDTO.Artist = "";
            Assert.False(ValidateModel(_productDTO));
        }   

        [Fact]
        public void Should_Fail_Year_Min()
        {
            _productDTO.Year = -1;
            Assert.False(ValidateModel(_productDTO));
        }  

        [Fact]
        public void Should_Fail_Year_Max()
        {
            _productDTO.Year = 2025;
            Assert.False(ValidateModel(_productDTO));
        }                       

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}