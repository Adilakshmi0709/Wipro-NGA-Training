using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MySecureApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            ViewBag.Message = "Welcome, User! Here is your profile information.";
            return View();
        }
    }
}