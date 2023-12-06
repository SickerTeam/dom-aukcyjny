using System.ComponentModel.DataAnnotations;

namespace backend.Validation;

public class FutureDateAttribute(int days) : ValidationAttribute
{
    private readonly int _days = days;

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime dateTime)
        {
            DateTime maxDate = DateTime.Now.AddDays(_days);
            if (dateTime > maxDate)
            {
                return new ValidationResult($"Date must be less than or equal to {maxDate}");
            }
        }

        return ValidationResult.Success!;
        // If you want to get rid of this warning, you can use the null-forgiving post-fix ! operator to tell the compiler that you're sure the expression will not evaluate to null:
        // In our case, ValidationResult.Success is not null, it's a static read-only field that represents a successful validation and it's value is null
    }
}
