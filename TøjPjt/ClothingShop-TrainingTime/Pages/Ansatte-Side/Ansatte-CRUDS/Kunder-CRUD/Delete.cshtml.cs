using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;

namespace ClothingShop_TrainingTime.Pages.Ansatte_Side.Ansatte_CRUDS.Kunder_CRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ClothingShop_TrainingTime.Data.ClothDBContext _context;

        public DeleteModel(ClothingShop_TrainingTime.Data.ClothDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kunder Kunder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunder = await _context.Kunders.FirstOrDefaultAsync(m => m.KundeId == id);

            if (kunder == null)
            {
                return NotFound();
            }
            else
            {
                Kunder = kunder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunder = await _context.Kunders.FindAsync(id);
            if (kunder != null)
            {
                Kunder = kunder;
                _context.Kunders.Remove(Kunder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
