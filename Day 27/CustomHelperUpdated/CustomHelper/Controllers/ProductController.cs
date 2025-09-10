using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_Wipro_demo1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var product = new { Id = id, Name = "Sample Product" };

            ViewBag.prdid = product.Id;
            ViewBag.prdName = product.Name;
            return View(product);
        }
    }
}
