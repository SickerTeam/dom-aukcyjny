using System.ComponentModel.DataAnnotations;

namespace backend.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        private readonly int maxDaysIntoFuture = 14;

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                DateTime maxDate = DateTime.Now.AddDays(maxDaysIntoFuture).AddMinutes(1);
                if (dateTime < DateTime.Now || dateTime > maxDate)
                {
                    return new ValidationResult($"Date must be within the range of now to {maxDate}");
                }
            }

            return ValidationResult.Success!;
        }
    }
}