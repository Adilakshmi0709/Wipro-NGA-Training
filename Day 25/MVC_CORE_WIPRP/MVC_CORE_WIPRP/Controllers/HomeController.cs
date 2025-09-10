using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_CORE_WIPRP.Models;

namespace MVC_CORE_WIPRP.Controllers
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

        // ✅ Viewdemo with single Employee
        public IActionResult viewdemo()
        {
            Employee e1 = new Employee
            {
                empid = 101,
                firstname = "Rushikesh",
                lastname = "Magdum",
                city = "Sangli"
            };

            return View(e1);
        }

        // ✅ ibmview with another Employee
        public IActionResult ibmview()
        {
            Employee e2 = new Employee
            {
                empid = 102,
                firstname = "Amit",
                lastname = "Patil",
                city = "Pune"
            };

            return View(e2);
        }
    }
}
