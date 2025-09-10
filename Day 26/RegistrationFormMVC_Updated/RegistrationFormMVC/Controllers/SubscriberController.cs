using Microsoft.AspNetCore.Mvc;
using RegistrationFormMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationFormMVC.Controllers
{
    public class SubscriberController : Controller
    {
        // Fake database (list)
        private static List<Subscriber> subscribers = new List<Subscriber>();
        private static int counter = 1;

        // READ (List all subscribers)
        public IActionResult Index()
        {
            return View(subscribers);
        }

        // CREATE (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Subscriber model)
        {
            if (ModelState.IsValid)
            {
                model.Id = counter++;
                subscribers.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // UPDATE (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subscriber = subscribers.FirstOrDefault(s => s.Id == id);
            return View(subscriber);
        }

        // UPDATE (POST)
        [HttpPost]
        public IActionResult Edit(Subscriber model)
        {
            var subscriber = subscribers.FirstOrDefault(s => s.Id == model.Id);
            if (subscriber != null)
            {
                subscriber.Username = model.Username;
                subscriber.Email = model.Email;
                subscriber.Password = model.Password;
            }
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var subscriber = subscribers.FirstOrDefault(s => s.Id == id);
            if (subscriber != null)
            {
                subscribers.Remove(subscriber);
            }
            return RedirectToAction("Index");
        }
    }
}
