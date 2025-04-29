using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe.Checkout;
using Stripe;
using Newtonsoft.Json;
using ClothingShop_TrainingTime.Data;

namespace ClothingShop_TrainingTime.Pages.PaymentFolder.BetalingsFormer
{
    public class BetalingController : Controller
    {
        private ClothDBContext _context;
        public BetalingController(ClothDBContext context)
        {
            _context = context;
        }

            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
        public IActionResult CreateCheckoutSession()
        {
            var getProduct = HttpContext.Session.GetString("TheProductIds");
            if (!string.IsNullOrEmpty(getProduct))
            {
                var ids = JsonConvert.DeserializeObject<List<int>>(getProduct);
                HttpContext.Session.SetString("TheProductIds", JsonConvert.SerializeObject(ids));

                var theproduct = ids.FirstOrDefault();
                var produkt = _context.Produkters.FirstOrDefault(x => x.ProduktId == theproduct);


                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                Currency = "dkk",
                                UnitAmount = (long?)(produkt.Pris * 0.5m),
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = "Mit produkt",
                                },
                            },
                            Quantity = 1,
                        },
                    },
                    Mode = "payment",
                    SuccessUrl = "https://localhost:7230/Betaling/Success",
                    CancelUrl = "https://localhost:7230/Betaling/Cancel",
                };

                var service = new SessionService();
                Session session = service.Create(options);

                return Redirect(session.Url);
            }

            // Handle the case where getProduct is null or empty
            return BadRequest("No product IDs found in session.");
        }

            public IActionResult Success()
            {
                return Content("Betaling gennemført!");
            }

            public IActionResult Cancel()
            {
                return Content("Betaling afbrudt.");
            }


    }
}



