using EcommerceMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly EcommerceDbContext _context;

        public HomeController(EcommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");
            ViewBag.Username = username;
            return View(_context.Products.ToList());
        }
    }
}
