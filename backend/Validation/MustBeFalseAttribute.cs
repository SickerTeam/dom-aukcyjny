using System.ComponentModel.DataAnnotations;

namespace backend.Validation;
public class MustBeFalseAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool v && !v;
    }
}