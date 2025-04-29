using Azure.Identity;
using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.LibraryModel;
using NuGet.Protocol;

namespace ClothingShop_TrainingTime.Pages.UserSider
{
    public class UserAdressModel : PageModel
    {
        private ClothDBContext _context;
        public UserAdressModel(ClothDBContext context)
        {
            _context = context;
        }
        public List<Kunder> Kunder { get; set; } = new List<Kunder>();
        public Adresse Adresse { get; set; }

        public void OnGet()
        {
            ViewData["Vejnavn"] = new SelectList(
                _context.Adresses.Select(k => new { k.Vejnavn, k.Postnummer, k.City, k.BrugerId }),
                "Vejnavn",
                "Vejnavn"
            );
        }

        public IActionResult OnPostGodekend(Adresse adresse)
        {
            var TheNewAdress = _context.Adresses.FirstOrDefault(k => k.Vejnavn == adresse.Vejnavn);
            _context.SaveChanges();

            if (TheNewAdress != null)
            {

                Levering levering = new Levering
                {
                    LeveringsStatus = "Under behandling",
                    ForventetLeveringDato = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                    TrackingNummer = "TRACK5678973",
                    OrdreId = TheNewAdress.BrugerId,
                    
                    
                };

                _context.Leverings.Add(levering);
                _context.SaveChanges();

                // here is to send a message
                //TempData["PopupMessage"] = $"Levering oprettet med trackingnummer: {levering.TrackingNummer}" +
                //    $" og leveringsdato: {levering.ForventetLeveringDato}" +
                //    $" og leveringsstatus: {levering.LeveringsStatus}";

                //here we want to get the product 

                
                return RedirectToPage("/PaymentFolder/BetalingsFormer/Betaling");
            }
            else
            {
                return Page();
            }
        }
    }
}
