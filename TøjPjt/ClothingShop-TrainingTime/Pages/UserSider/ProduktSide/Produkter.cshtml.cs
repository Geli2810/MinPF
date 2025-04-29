using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using ClothingShop_TrainingTime.Pages.Services.Produkt_Services;
using ClothingShop_TrainingTime.Pages.TheSearchProduct;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClothingShop_TrainingTime.Pages.UserSider.ProduktSide
{
    public class ProdukterModel : PageModel
    {
        private ClothDBContext ClothDBContext;
        private ProduktServices TheProductsModel;
        private TheProductsModel TheProductsModel1;
        public ProdukterModel(ClothDBContext context, ProduktServices productsModel, TheProductsModel theProductsModel1)
        {
            ClothDBContext = context;
            TheProductsModel1 = theProductsModel1;
            TheProductsModel = productsModel;
        }

        public List<Produkter> Produkter { get; set; } = new();

        public void OnGet()
        {
            Produkter = ClothDBContext.Produkters.ToList();
        }



    }
}
