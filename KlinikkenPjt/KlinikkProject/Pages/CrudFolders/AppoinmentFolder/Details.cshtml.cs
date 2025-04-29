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
    public class DetailsModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public DetailsModel(KlinikkProject.Models.DoctorDBContext context)
        {
            _context = context;
        }

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
    }
}
