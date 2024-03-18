using ServiceContracts.DTO;
using System;
using System.ComponentModel.DataAnnotations;


namespace Services.Helpers
{
    public class ValidationHelper
    {
        internal static void ModelValidation(object obj)
        {
            //Model Validations
            ValidationContext? validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResultsList = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResultsList, true);
            if (!isValid)
            {
                throw new ArgumentException(validationResultsList.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
