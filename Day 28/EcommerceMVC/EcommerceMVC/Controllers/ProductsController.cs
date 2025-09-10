using EcommerceMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EcommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceDbContext _context;

        public ProductsController(EcommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();  // ✅ fetch from DB
            return View(products);
        }
    }
}
