using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ContactManager.Pages.Admin
{
    // Only admins can see this page
    [Authorize(Roles = "ContactAdministrators")]
    public class UsersModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // This list will hold all users from the database
        public IList<IdentityUser> Users { get; set; } = new List<IdentityUser>();

        public void OnGet()
        {
            // Load all registered users (clients + admin)
            Users = _userManager.Users.ToList();
        }
    }
}
