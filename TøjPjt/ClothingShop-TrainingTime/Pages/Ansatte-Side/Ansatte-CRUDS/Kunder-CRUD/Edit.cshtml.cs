using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;

namespace ClothingShop_TrainingTime.Pages.Ansatte_Side.Ansatte_CRUDS.Kunder_CRUD
{
    public class EditModel : PageModel
    {
        private readonly ClothingShop_TrainingTime.Data.ClothDBContext _context;

        public EditModel(ClothingShop_TrainingTime.Data.ClothDBContext context)
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

            var kunder =  await _context.Kunders.FirstOrDefaultAsync(m => m.KundeId == id);
            if (kunder == null)
            {
                return NotFound();
            }
            Kunder = kunder;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kunder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KunderExists(Kunder.KundeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KunderExists(int id)
        {
            return _context.Kunders.Any(e => e.KundeId == id);
        }
    }
}
