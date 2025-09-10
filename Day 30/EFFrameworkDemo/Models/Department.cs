using System.Collections.Generic;

namespace EFFrameworkDemo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // ✅ avoid CS8618

        // Navigation property
        public ICollection<Employee> Employee { get; set; } = new List<Employee>();  // ✅ avoids null warning
    }
}