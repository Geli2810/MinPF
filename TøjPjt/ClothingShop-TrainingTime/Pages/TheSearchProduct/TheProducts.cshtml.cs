using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using ClothingShop_TrainingTime.Pages.UserSider.ProduktSide;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClothingShop_TrainingTime.Pages.TheSearchProduct
{
    public class TheProductsModel : PageModel
    {
        public List<Produkter> Produkter { get; set; } = new();
        public ClothDBContext clothDBContext;
        public VidersendeProduktModel VidereSendeProductModel;
        public TheProductsModel(ClothDBContext context, VidersendeProduktModel videreSendeProductModel)
        {
            clothDBContext = context;
            VidereSendeProductModel = videreSendeProductModel;
        }
        public void OnPostFilter(string kategori)
        {
            if (!string.IsNullOrEmpty(kategori))
            {
                Produkter = clothDBContext.Produkters
                    .Where(x => x.Kategori != null && x.Kategori.Navn == kategori).GroupBy(x => x.Navn) // Group by Navn
                    .Select(x => x.First()) // Select the first item in each group
                    .ToList();
            }
        }

        public IActionResult OnPostTheSpecificProduct(string Navn)
        {
            if (string.IsNullOrEmpty(Navn))
            {
                return Page();
            }
            Produkter = clothDBContext.Produkters
                    .Where(x => x.Navn != null && x.Navn.Contains(Navn.ToLower())).GroupBy(x => x.Navn).
                    Select(x => x.First()).ToList();
                    
            return Page();
        }

        public IActionResult OnPostTheGivenProduct(int ProduktId)
        {

            TempData["ProduktId"] = ProduktId;
            return RedirectToPage("/UserSider/ProduktSide/VidersendeProdukt");

        }
        public void OnPostAddingToTheCard(int produktId)
        {
            var produkt = clothDBContext.Produkters.FirstOrDefault(x => x.ProduktId == produktId);
            if (produkt != null)
            {
                // Add the product to the shopping cart
                // Implement your logic here to add the product to the cart
            }
        }

    }
}
