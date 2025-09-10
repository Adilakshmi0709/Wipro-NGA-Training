# Add content to the interface file
@"
using rep_pattern_demo.Models;

namespace rep_pattern_demo.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int employeeId);
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int employeeId);
    }
}
"@ | Out-File -FilePath "Repository\IEmployeeRepository.cs" -Encoding UTF8