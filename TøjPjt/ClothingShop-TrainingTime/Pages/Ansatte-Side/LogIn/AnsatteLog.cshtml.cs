using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClothingShop_TrainingTime.Pages.Ansatte_Side.LogIn
{
    public class AnsatteLogModel : PageModel
    {
        private ClothDBContext ClothDBContext;
        public AnsatteLogModel(ClothDBContext context)
        {
            ClothDBContext = context;
        }
        List<Brugere> ansatte { get; set; } = new();
        public void OnGet()
        {
            ansatte = ClothDBContext.Brugeres.ToList();
        }

        [BindProperty]
        public string AnsatteRolle { get; set; }

        public static Brugere AnsatteErHer { get; set; } = new();

        public IActionResult OnPostAnsatte()
        {
            var Personen = ClothDBContext.Brugeres.FirstOrDefault();
            if (Personen != null && AnsatteRolle == Personen.Rolle && Personen.Rolle.Contains("Admin"))
            {

                HttpContext.Session.SetString("Ansatte", AnsatteRolle);
                AnsatteErHer = Personen;
                return RedirectToPage("/Index");
            }
            else if (Personen != null && Personen.Rolle == "Kunde")
            {
                ModelState.AddModelError("", "Dette er kun for ansatte");
                return Page();
            }
                ModelState.AddModelError("", "Forkert Rolle");
            return Page();
        }
    }
}

