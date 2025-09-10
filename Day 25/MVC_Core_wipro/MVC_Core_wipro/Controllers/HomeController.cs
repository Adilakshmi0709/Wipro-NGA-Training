//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using MVC_Core_wipro.Models;
//using System.Collections.Generic;

//namespace MVC_Core_wipro.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }

//        public IActionResult wipro()
//        {
//            // ? Create a list of Employees
//            List<Employee> employees = new List<Employee>
//            {
//                new Employee { empid = 101, firstname = "Rushikesh", lastname = "Magdum", city = "Sangli" },
//                new Employee { empid = 102, firstname = "Sneha", lastname = "Patil", city = "Pune" },
//                new Employee { empid = 103, firstname = "Rohan", lastname = "Sharma", city = "Mumbai" }
//            };

//            return View(employees); // ? send list to view
//        }
//    }
//}


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_wipro.Models;
using System.Collections.Generic;

namespace MVC_Core_wipro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult wipro()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { empid = 101, firstname = "Rushikesh", lastname = "Magdum", city = "Sangli" },
                new Employee { empid = 102, firstname = "Amit", lastname = "Patil", city = "Pune" },
                new Employee { empid = 103, firstname = "Sneha", lastname = "Desai", city = "Mumbai" }
            };

            return View(employees);
        }
    }
}
