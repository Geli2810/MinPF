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
    public class DetailsModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public DetailsModel(KlinikkProject.Models.DoctorDBContext context)
        {
            _context = context;
        }

        public Tider Tider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _context.Tiders.Include(t => t.Lægerne).LoadAsync();
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
    }
}
