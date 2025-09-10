using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFFrameworkDemo.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)      // Each Employee has ONE Department
                    .WithMany(p => p.Employee)       // Each Department has MANY Employees  
                    .HasForeignKey(d => d.DepartmentId)   // FK is DepartmentId in Employee table
                    .OnDelete(DeleteBehavior.ClientSetNull)   // If Department deleted → Employee.DepartmentId = NULL
                    .HasConstraintName("FK_Employee_Department") ; 
            });


        }
    }
}
