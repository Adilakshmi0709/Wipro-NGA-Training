namespace EFFrameworkDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        public string Name { get; set; } = string.Empty;   // ✅ prevents null warning
        public string Designation { get; set; } = string.Empty;  // ✅

        // Navigation Property
        public Department Department { get; set; }   // ✅ Correct type
    }
}