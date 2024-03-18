using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ControllersExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value !=null)
            {
                DateTime? ToDateValue = Convert.ToDateTime(value);
                
                PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if(OtherProperty != null)
                {
                    DateTime FromDateValue = Convert.ToDateTime(OtherProperty.GetValue(validationContext.ObjectInstance));
                    if(ToDateValue < FromDateValue)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName});
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
