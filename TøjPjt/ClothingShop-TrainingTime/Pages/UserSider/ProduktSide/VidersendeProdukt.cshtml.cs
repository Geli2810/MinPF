using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothingShop_TrainingTime.Pages.UserSider.ProduktSide
{
    public class VidersendeProduktModel : PageModel
    {
        private ClothDBContext ClothDBContext;
        public VidersendeProduktModel(ClothDBContext clothDB)
        {
            ClothDBContext = clothDB;
            Produkter = new List<Produkter>();
        }



        [BindProperty(SupportsGet = true)]
        public List<Produkter> Produkter { get; set; }

        public void OnGet()
        {
            if (TempData["ProduktId"] is int produktId)
            {
                var produkt = ClothDBContext.Produkters.FirstOrDefault(x => x.ProduktId == produktId);
                if (produkt != null)
                {
                    Produkter.Add(produkt);
                }
            }

            var farverTilProdukt = ClothDBContext.Produkters
                .Where(p => p.Navn == Produkter.First().Navn)
                .Select(p=> p.Farve).GroupBy(x => x).Select(x => x.First())
                .ToList();
            ViewData["Farve"] = new SelectList(farverTilProdukt);

            var Størrelse = ClothDBContext.Produkters
                .Where(p => p.Navn == Produkter.First().Navn)
                .Select(p => p.Størrelse)
                .Distinct()
                .ToList();

            ViewData["Størrelse"] = new SelectList(Størrelse);
        }


        public IActionResult OnPostAddingToTheCard(int ProduktId, string Farve, string Størrelse)
        {
            var valgtProdukt = ClothDBContext.Produkters
                .FirstOrDefault(p =>
                    p.Navn == ClothDBContext.Produkters.First(x => x.ProduktId == ProduktId).Navn &&
                    p.Farve == Farve &&
                    p.Størrelse == Størrelse);


            if (valgtProdukt != null)
            {
                var existingIdsString = HttpContext.Session.GetString("TheProductIds");
                List<int> ids = string.IsNullOrEmpty(existingIdsString) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(existingIdsString)!;

                ids?.Add(valgtProdukt.ProduktId);

                HttpContext.Session.SetString("TheProductIds", JsonConvert.SerializeObject(ids));

                return RedirectToPage("/PaymentFolder/Card");
            }

            return Page();
        }

        public IActionResult OnPostRemoveFromCard(int produktId)
        {
            var existingIdsString = HttpContext.Session.GetString("TheProductIds");
            List<int> ids = string.IsNullOrEmpty(existingIdsString) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(existingIdsString)!;
            if (ids != null && ids.Contains(produktId))
            {
                ids.Remove(produktId);
                HttpContext.Session.SetString("TheProductIds", JsonConvert.SerializeObject(ids));
            }
            return RedirectToPage("/PaymentFolder/Card");
        }
    }
}
