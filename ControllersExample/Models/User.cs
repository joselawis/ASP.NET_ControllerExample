using System.ComponentModel.DataAnnotations;

namespace ControllersExample.Models
{
    public class User
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

        public override string ToString()
        {
            return $"User object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }
    }
}