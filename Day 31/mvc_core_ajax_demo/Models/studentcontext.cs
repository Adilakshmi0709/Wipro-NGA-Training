using Microsoft.EntityFrameworkCore;
using mvccore_ajax_demo.Models;

namespace mvccore_ajax_demo.Models;

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }
}