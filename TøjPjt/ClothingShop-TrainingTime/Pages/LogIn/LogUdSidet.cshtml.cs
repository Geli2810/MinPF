using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClothingShop_TrainingTime.Pages.LogIn
{
    public class LogUdSidetModel : PageModel
    {

        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("TheProductIds");

            return RedirectToPage("/Index");
        }
    }
}
