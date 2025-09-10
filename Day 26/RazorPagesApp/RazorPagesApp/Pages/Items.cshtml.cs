using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace RazorPagesApp.Pages
{
    public class ItemsModel : PageModel
    {
        public static List<string> ItemList = new List<string>();

        public void OnGet()
        {
        }
    }
}
