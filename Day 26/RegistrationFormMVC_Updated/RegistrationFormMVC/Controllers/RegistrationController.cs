using Microsoft.AspNetCore.Mvc;
using RegistrationFormMVC.Models;

namespace RegistrationFormMVC.Controllers
{
    public class RegistrationController : Controller
    {
        private static List<RegistrationModel> registeredCandidates = new List<RegistrationModel>();

        // CREATE (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                registeredCandidates.Add(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        // READ (List all)
        public IActionResult List()
        {
            return View(registeredCandidates);
        }

        // UPDATE (GET form to edit)
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var candidate = registeredCandidates.FirstOrDefault(c => c.EmployeeId == id);
            if (candidate == null) return NotFound();

            return View(candidate);
        }

        // UPDATE (POST save changes)
        [HttpPost]
        public IActionResult Edit(RegistrationModel model)
        {
            var candidate = registeredCandidates.FirstOrDefault(c => c.EmployeeId == model.EmployeeId);
            if (candidate == null) return NotFound();

            candidate.Name = model.Name;
            candidate.City = model.City;
            candidate.Gender = model.Gender;
            candidate.Qualification = model.Qualification;
            candidate.Password = model.Password;

            return RedirectToAction("List");
        }

        // DELETE (GET confirm)
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var candidate = registeredCandidates.FirstOrDefault(c => c.EmployeeId == id);
            if (candidate == null) return NotFound();

            return View(candidate);
        }

        // DELETE (POST remove)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var candidate = registeredCandidates.FirstOrDefault(c => c.EmployeeId == id);
            if (candidate != null)
                registeredCandidates.Remove(candidate);

            return RedirectToAction("List");
        }
    }
}
