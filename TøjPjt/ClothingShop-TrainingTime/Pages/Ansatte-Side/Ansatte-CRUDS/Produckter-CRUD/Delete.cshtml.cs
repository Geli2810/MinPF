using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;

namespace ClothingShop_TrainingTime.Pages.Ansatte_Side.Ansatte_CRUDS.Produckter_CRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ClothingShop_TrainingTime.Data.ClothDBContext _context;

        public DeleteModel(ClothingShop_TrainingTime.Data.ClothDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produkter Produkter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkter = await _context.Produkters.FirstOrDefaultAsync(m => m.ProduktId == id);

            if (produkter == null)
            {
                return NotFound();
            }
            else
            {
                Produkter = produkter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkter = await _context.Produkters.FindAsync(id);
            if (produkter != null)
            {
                Produkter = produkter;
                _context.Produkters.Remove(Produkter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
