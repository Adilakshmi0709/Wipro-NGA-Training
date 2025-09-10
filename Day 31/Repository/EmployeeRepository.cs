using rep_pattern_demo.Models;

namespace rep_pattern_demo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employee.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public int AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            return _context.SaveChanges();
        }

        public int UpdateEmployee(Employee employee)
        {
            _context.Employee.Update(employee);
            return _context.SaveChanges();
        }

        public int DeleteEmployee(int employeeId)
        {
            var employee = _context.Employee.Find(employeeId);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}