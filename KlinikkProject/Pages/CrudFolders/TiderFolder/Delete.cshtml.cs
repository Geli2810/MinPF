using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KlinikkProject.Models;

namespace KlinikkProject.Pages.TiderFolder
{
    public class DeleteModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public DeleteModel(KlinikkProject.Models.DoctorDBContext context)
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

            var tider = await _context.Tiders.FirstOrDefaultAsync(m => m.Id == id);

            if (tider == null)
            {
                return NotFound();
            }
            else
            {
                Tider = tider;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tider = await _context.Tiders.FindAsync(id);
            if (tider != null)
            {
                Tider = tider;
                _context.Tiders.Remove(Tider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../TheAdministrationSite");
        }
    }
}
