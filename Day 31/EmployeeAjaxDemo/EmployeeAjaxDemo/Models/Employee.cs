using System.ComponentModel.DataAnnotations;

namespace EmployeeAjaxDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;

        [Range(1000, 1000000)]
        public decimal Salary { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;
    }
}
