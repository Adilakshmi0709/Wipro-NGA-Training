using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace core_razor_recap.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public string Message { get; set; }

        public void OnPost()
        {
            Message = $"{Name}, information will be sent to {Email}";
        }
    }
}
