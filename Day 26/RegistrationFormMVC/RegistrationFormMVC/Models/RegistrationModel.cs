using System.ComponentModel.DataAnnotations;

namespace RegistrationFormMVC.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Employee ID must be numeric")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Select at least one qualification")]
        public List<string> Qualification { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password must be 6–12 characters")]
        public string Password { get; set; }
    }
}
