using System.ComponentModel.DataAnnotations;

namespace backend.Validation
{
    public class CurrentDateTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {

            if (value == null) // CreatedAt Not included in [PUT] update is OK
            {
                return true;
            }

            if (value is DateTime dateTime)
            {
                var oneMinuteAgo = DateTime.Now.AddMinutes(-1);
                return dateTime >= oneMinuteAgo && dateTime <= DateTime.Now;
            }
            return false;
        }
    }
}