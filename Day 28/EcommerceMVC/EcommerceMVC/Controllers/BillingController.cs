using EcommerceMVC.Data;
using EcommerceMVC.Models;
using EcommerceMVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class BillingController : Controller
    {
        private readonly EcommerceDbContext _context;

        public BillingController(EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: /Billing/Checkout
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            ViewBag.TotalAmount = cart.Sum(c => c.Price * c.Quantity);
            ViewBag.CartItems = cart;
            return View(new BillingInfo()); // Pass empty BillingInfo model
        }

        // POST: /Billing/Checkout
        [HttpPost]
        public IActionResult Checkout(BillingInfo info)
        {
            if (!ModelState.IsValid)
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
                ViewBag.TotalAmount = cart.Sum(c => c.Price * c.Quantity);
                ViewBag.CartItems = cart;
                return View(info);
            }

            var cartItems = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Save order in DB
            foreach (var item in cartItems)
            {
                var order = new Order
                {
                    Username = info.Name, // mapping Name to Username
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    TotalAmount = item.Price * item.Quantity,
                    OrderDate = DateTime.Now
                };

                _context.Orders.Add(order);
            }

            _context.SaveChanges();

            // Clear cart
            HttpContext.Session.Remove("Cart");

            return View("Success");
        }
    }
}
