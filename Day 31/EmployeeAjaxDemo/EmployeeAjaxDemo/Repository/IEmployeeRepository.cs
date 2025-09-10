using EmployeeAjaxDemo.Models;
using System.Collections.Generic;

namespace EmployeeAjaxDemo.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        void SaveEmployee();
    }
}
