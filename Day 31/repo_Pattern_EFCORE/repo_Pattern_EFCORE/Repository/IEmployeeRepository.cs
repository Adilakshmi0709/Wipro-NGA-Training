using System.Collections.Generic;
using repo_Pattern_EFCORE.Models;

namespace repo_Pattern_EFCORE.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee? GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        void SaveEmployee();
    }
}
