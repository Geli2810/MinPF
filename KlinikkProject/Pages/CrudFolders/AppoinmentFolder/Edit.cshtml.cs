using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KlinikkProject.Models;

namespace KlinikkProject.Pages.AppoinmentFolder
{
    public class EditModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public EditModel(KlinikkProject.Models.DoctorDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lægerne Lægerne { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lægerne =  await _context.Lægernes.FirstOrDefaultAsync(m => m.Id == id);
            if (lægerne == null)
            {
                return NotFound();
            }
            Lægerne = lægerne;
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

            _context.Attach(Lægerne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LægerneExists(Lægerne.Id))
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

        private bool LægerneExists(int id)
        {
            return _context.Lægernes.Any(e => e.Id == id);
        }
    }
}
