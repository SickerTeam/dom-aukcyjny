using Xunit;
using backend.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Testing.Validation
{
    public class InstaBuyRegistrationDTOValidationTest
    {
        private readonly InstaBuyRegistrationDTO _instaBuyRegistrationDTO;

        public InstaBuyRegistrationDTOValidationTest()
        {
            _instaBuyRegistrationDTO = new InstaBuyRegistrationDTO(1, 0.01m);
        }

        [Fact]
        public void Should_Pass_With_Min_Values()
        {
            var result = ValidateModel(_instaBuyRegistrationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Pass_With_Max_Values()
        {
            _instaBuyRegistrationDTO.ProductId = int.MaxValue;
            _instaBuyRegistrationDTO.Price = decimal.MaxValue;
            var result = ValidateModel(_instaBuyRegistrationDTO);
            Assert.True(result);
        }

        [Fact]
        public void Should_Fail_ProductId_Min()
        {
            _instaBuyRegistrationDTO.ProductId = 0;
            var result = ValidateModel(_instaBuyRegistrationDTO);
            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_Price_Min()
        {
            _instaBuyRegistrationDTO.Price = 0.00m;
            var result = ValidateModel(_instaBuyRegistrationDTO);
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