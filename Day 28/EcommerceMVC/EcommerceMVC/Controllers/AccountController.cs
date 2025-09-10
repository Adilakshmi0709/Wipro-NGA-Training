using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class AccountController : Controller
    {
        // ✅ Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // ✅ Login Logic
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Dummy authentication — replace with DB later if needed
            if (username == "admin" && password == "1234")
            {
                // Store username in session
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid username or password!";
            return View();
        }

        // ✅ Logout Logic
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
