using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KlinikkProject.Models;

namespace KlinikkProject.Pages.AppoinmentFolder
{
    public class DeleteModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public DeleteModel(KlinikkProject.Models.DoctorDBContext context)
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

            var lægerne = await _context.Lægernes.FirstOrDefaultAsync(m => m.Id == id);

            if (lægerne == null)
            {
                return NotFound();
            }
            else
            {
                Lægerne = lægerne;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lægerne = await _context.Lægernes.FindAsync(id);
            if (lægerne != null)
            {
                Lægerne = lægerne;
                _context.Lægernes.Remove(Lægerne);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
