using EmployeeAjaxDemo.Models;
using EmployeeAjaxDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAjaxDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _repository.GetAllEmployee();
            return Json(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.AddEmployee(employee);
                return Json(new { success = true, message = "Employee added successfully" });
            }
            return Json(new { success = false, message = "Validation failed" });
        }
    }
}
