using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KlinikkProject.Models;

namespace KlinikkProject.Pages.TiderFolder
{
    public class EditModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public EditModel(KlinikkProject.Models.DoctorDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tider Tider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tider =  await _context.Tiders.FirstOrDefaultAsync(m => m.Id == id);
            if (tider == null)
            {
                return NotFound();
            }
            Tider = tider;
           ViewData["LægerneId"] = new SelectList(_context.Lægernes, "Id", "Id");
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

            _context.Attach(Tider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiderExists(Tider.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../TheAdministrationSite");
        }

        private bool TiderExists(int id)
        {
            return _context.Tiders.Any(e => e.Id == id);
        }
    }
}
