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

namespace ClothingShop_TrainingTime.Pages.Ansatte_Side.Ansatte_CRUDS.Produckter_CRUD
{
    public class EditModel : PageModel
    {
        private readonly ClothingShop_TrainingTime.Data.ClothDBContext _context;

        public EditModel(ClothingShop_TrainingTime.Data.ClothDBContext context)
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

            var produkter =  await _context.Produkters.FirstOrDefaultAsync(m => m.ProduktId == id);
            if (produkter == null)
            {
                return NotFound();
            }
            Produkter = produkter;
           ViewData["KategoriId"] = new SelectList(_context.Kategoriers, "KategoriId", "KategoriId");
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

            _context.Attach(Produkter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdukterExists(Produkter.ProduktId))
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

        private bool ProdukterExists(int id)
        {
            return _context.Produkters.Any(e => e.ProduktId == id);
        }
    }
}
