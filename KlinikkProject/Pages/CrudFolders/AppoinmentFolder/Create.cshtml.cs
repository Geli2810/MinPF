using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KlinikkProject.Models;

namespace KlinikkProject.Pages.AppoinmentFolder
{
    public class CreateModel : PageModel
    {
        private readonly KlinikkProject.Models.DoctorDBContext _context;

        public CreateModel(KlinikkProject.Models.DoctorDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lægerne Lægerne { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lægernes.Add(Lægerne);
            await _context.SaveChangesAsync();

            return RedirectToPage("../TheAdministrationSite");
        }
    }
}
