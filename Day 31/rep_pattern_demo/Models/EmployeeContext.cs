using Microsoft.EntityFrameworkCore;

namespace rep_pattern_demo.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}