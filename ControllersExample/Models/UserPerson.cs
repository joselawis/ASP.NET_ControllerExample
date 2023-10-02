using System.ComponentModel.DataAnnotations;
using ControllersExample.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControllersExample.Models
{
    public class UserPerson : IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]+$", ErrorMessage = "{0} should contain only alphabets, space and dot")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage = "{0} can't be empty")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should contain 9 digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be empty")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be empty")]
        [Compare("Password", ErrorMessage = "{0} and {1} must be the same")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be between €{1} and €{2}")]
        public double? Price { get; set; }

        [MinimumYearValidator(2000, ErrorMessage = "{0} should not be after Jan 01, {1}")]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }


        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<string?> Tags { get; set; } = new List<string?>();

        public override string ToString()
        {
            return $"User object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}, Date Of Birth: {DateOfBirth}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of Date of Birth or Age must be supplied", new[] { nameof(Age) });
            }
        }
    }
}
