using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int studentID { get; set; }
    [Required]
    public string studentName { get; set; }
    [Required]
    public string studentAddress { get; set; }
} // The closing brace was missing