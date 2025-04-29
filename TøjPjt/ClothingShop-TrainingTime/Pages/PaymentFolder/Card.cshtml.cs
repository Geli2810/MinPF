using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using NuGet.Configuration;
using Stripe;
using System.Threading.Tasks;

namespace ClothingShop_TrainingTime.Pages.PaymentFolder
{
    public class CardModel : PageModel
    {
        private readonly ClothDBContext ClothDBContext;
        public List<Produkter> Produkter { get; set; } = new();

        public decimal TheRabat {
            get { return 0.05m; } }

        public CardModel(ClothDBContext ClothDBContext)
        {
            this.ClothDBContext = ClothDBContext;
        }

        public void OnGet()
        {
            if(HttpContext.Session.GetString("User") != null || HttpContext.Session.GetString("Ansatte") != null)
            {

                var json = HttpContext.Session.GetString("TheProductIds");
                if (!string.IsNullOrEmpty(json))
                {
                    var ids = JsonConvert.DeserializeObject<List<int>>(json);

                    var theProdukter = ClothDBContext.Produkters
                        .Where(p => ids.Contains(p.ProduktId))
                        .ToList();

                    if (theProdukter.Any())
                    {
                        var ordre = new Ordrer
                        {
                            KundeId = ClothDBContext.Kunders.First().KundeId,

                            OrdreLinjers = theProdukter.Select(p => new OrdreLinjer
                            {
                                ProduktId = p.ProduktId,
                                Pris = p.Pris ?? 0,
                                Antal = 1

                            }).ToList()
                        };

                        ClothDBContext.Ordrers.Add(ordre);
                        ClothDBContext.SaveChanges();

                        Produkter = theProdukter;
                        
                    }
                }

            }
        }

        public IActionResult OnPostRemove(int ProduktId)
        {
            var json = HttpContext.Session.GetString("TheProductIds");
            if (!string.IsNullOrEmpty(json))
            {
                var ids = JsonConvert.DeserializeObject<List<int>>(json);
                ids.Remove(ProduktId);
                HttpContext.Session.SetString("TheProductIds", JsonConvert.SerializeObject(ids));
            }
            return RedirectToPage("/PaymentFolder/Card");

        }

        public IActionResult OnPostAdress()
        {
            // here we want to share the order with adress page
            var json = HttpContext.Session.GetString("TheProductIds");
            if (!string.IsNullOrEmpty(json))
            {
                var ids = JsonConvert.DeserializeObject<List<int>>(json);
                HttpContext.Session.SetString("TheProductIds", JsonConvert.SerializeObject(ids));
            }


            return RedirectToPage("/UserSider/Adress/UserAdress");

        }
    }
}
