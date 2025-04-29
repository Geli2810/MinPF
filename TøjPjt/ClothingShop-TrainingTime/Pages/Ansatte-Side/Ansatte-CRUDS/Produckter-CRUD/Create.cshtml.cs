using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;

namespace ClothingShop_TrainingTime.Pages.Ansatte_Side.Ansatte_CRUDS.Produckter_CRUD
{
    public class CreateModel : PageModel
    {
        private readonly ClothingShop_TrainingTime.Data.ClothDBContext _context;

        public CreateModel(ClothingShop_TrainingTime.Data.ClothDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["KategoriId"] = new SelectList(_context.Kategoriers, "KategoriId", "KategoriId");
            return Page();
        }

        [BindProperty]
        public Produkter Produkter { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produkters.Add(Produkter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
