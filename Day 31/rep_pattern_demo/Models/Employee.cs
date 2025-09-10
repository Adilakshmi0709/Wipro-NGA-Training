using System.ComponentModel.DataAnnotations;

namespace rep_pattern_demo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [Required]
        public string EmployeeName { get; set; } = string.Empty;
        
        [Required]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string EmailId { get; set; } = string.Empty;
    }
}