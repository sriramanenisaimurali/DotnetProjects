using System.ComponentModel.DataAnnotations;


namespace ControllersExample.CustomValidators
{
    public class MinAgeRequired : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 1900;
        public string DefaultErrorMessgae { get; set; } = "Year should not be less than {0}";
        //parameterless constructor
        public MinAgeRequired()
        {

        }
        //parameterized constructor
        public MinAgeRequired(int _minimumYear)
        {
            MinimumYear= _minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value !=null)
            {
                DateTime CurrentDate = DateTime.Now;
                DateTime BirthDate = (DateTime)value;
                if (BirthDate.Year < MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessgae, MinimumYear));
                }
                int age = CurrentDate.Year - BirthDate.Year;
                if(BirthDate.Month < CurrentDate.Month || (BirthDate.Month == CurrentDate.Month && CurrentDate.Day < BirthDate.Day))
                {
                    age--;
                }
                if(age<18)
                {
                    return new ValidationResult("Not Eligible because your age less than 18");
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
    }
}
