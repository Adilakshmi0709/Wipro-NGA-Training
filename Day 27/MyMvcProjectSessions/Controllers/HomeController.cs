//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using MyMvcProjectSessions.Models;
//
//namespace MyMvcProjectSessions.Controllers;
//
//public class HomeController : Controller
//{
    //private readonly ILogger<HomeController> _logger;
//
    //public HomeController(ILogger<HomeController> logger)
    //{
        //_logger = logger;
    //}
//
    //public IActionResult Index()
    //{
        //return View();
    //}
//
    //public IActionResult Privacy()
    //{
        //return View();
    //}
//
    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
//}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcProjectSessions.Models;

namespace MyMvcProjectSessions.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
//
    //public HomeController(ILogger<HomeController> logger)
    //{
        //_logger = logger;
    //}

    //public IActionResult Index()
    //{
    //return View();
    //}

    //public IActionResult Privacy()
    //{
    //return View();
    //}
    //
    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}

   private const string SessionName = "_Name";
 private const string SessionAge = "_Age";
 public IActionResult Index()
 {
     // Set session data
     HttpContext.Session.SetString(SessionName, "Rushikesh");
     HttpContext.Session.SetInt32(SessionAge, 22);
     return View();
 }
 public IActionResult About()
 {
     // Retrieve session data
     ViewBag.Name = HttpContext.Session.GetString(SessionName);
     ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);

     ViewData["Message"] = "ASP.NET Core!";
     return View();
 }
 public IActionResult Contact()
 {
     ViewData["Message"] = "Your contact page.";
     return View();
 }
 public IActionResult Error()
 {
     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
 }
}

