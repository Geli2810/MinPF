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
    public class IndexModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public IndexModel(KlinikkProject.Models.DoctorDBContext context)
        {
            _context = context;
        }

        public IList<Tider> Tider { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tider = await _context.Tiders
                .Include(t => t.Lægerne).ToListAsync();
        }
    }
}
