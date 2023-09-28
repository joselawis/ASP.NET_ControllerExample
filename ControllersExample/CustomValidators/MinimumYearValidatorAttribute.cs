using System.ComponentModel.DataAnnotations;

namespace ControllersExample.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        private int MinimumYear { get; set; } = 2000;

        private string DefaultErrorMessage { get; set; } = "Year should not be more than {0}";

        public MinimumYearValidatorAttribute()
        {

        }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            this.MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    if (ErrorMessage != null)
                    {
                        return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName, MinimumYear));
                    }
                    else
                    {
                        return new ValidationResult(string.Format(DefaultErrorMessage, MinimumYear));
                    }
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}