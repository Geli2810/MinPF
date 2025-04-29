using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ClothingShop_TrainingTime.Pages.LogIn
{
    public class LoginSideModel : PageModel
    {
        private ClothDBContext ClothDBContext; 
        public string ErrorMessage { get; set; }

        public LoginSideModel(ClothDBContext context)
        {
            ClothDBContext = context;
        }
        public List<Kunder> kunders { get; set; } = new();
        public void OnGet()
        {
            kunders = ClothDBContext.Kunders.ToList();
            if (TempData["Error"] is string error)
            {
                ErrorMessage = error;
            }
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public static Kunder kunder { get; set; } = new();

        public IActionResult OnPostLog()
        {
            var user = ClothDBContext.Kunders
                .FirstOrDefault(k => k.Email == Username && k.Telefon == Password); ClothDBContext.SaveChanges();
            if (user != null)
            {

                HttpContext.Session.SetString("User", Username);
                kunder = user;
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("", "Forkert login");
            return Page();
        }

        [BindProperty]
        public Kunder Kunden { get; set; }

        public async Task<IActionResult> OnPostAddUser()
        {
            if (string.IsNullOrEmpty(Kunden?.Email))
            {
                ModelState.AddModelError("", "Email cannot be null or empty.");
                return Page();
            }

            await ClothDBContext.Kunders.AddAsync(Kunden);
            await ClothDBContext.SaveChangesAsync();
            HttpContext.Session.SetString("User", Kunden.Email);
            return RedirectToPage("/Index");
        }

        

    }
}
