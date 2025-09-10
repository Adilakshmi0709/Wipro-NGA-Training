using EcommerceMVC.Data;
using EcommerceMVC.Models;
using EcommerceMVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly EcommerceDbContext _context;

        public OrderController(EcommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult PlaceOrder()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            var username = HttpContext.Session.GetString("Username") ?? "Guest";

            foreach (var item in cart)
            {
                var order = new Order
                {
                    Username = username,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    TotalAmount = item.Price * item.Quantity
                };
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
            HttpContext.Session.Remove("Cart");
            return View("OrderSuccess");
        }

        public IActionResult OrderHistory()
        {
            var username = HttpContext.Session.GetString("Username") ?? "Guest";
            var orders = _context.Orders.Where(o => o.Username == username).ToList();
            return View(orders);
        }
    }
}
