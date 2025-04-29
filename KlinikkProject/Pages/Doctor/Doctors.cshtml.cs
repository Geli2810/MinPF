using KlinikkProject.Models;
using KlinikkProject.Pages.Services.EFServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KlinikkProject.Pages.Doctor
{
    public class DoctorsModel : PageModel
    {
        private DoctorDBContext _context;
        [BindProperty]
        public Tider? Tider { get; set; }

        public DoctorsModel(DoctorDBContext context)
        {
            _context = context;
        }

        public List<Lægerne> DoctorList { get; set; } = new List<Lægerne>();
        public async Task OnGetAsync()
        {
            DoctorList = await _context.Lægernes.ToListAsync();
        }

        public IActionResult OnPostBestilTid(int id)
        {
            List<Tider> items = _context.Lægernes
                .Where(x => x.Id == id)
                .SelectMany(x => x.Tiders).ToList();


            DoctorAppoinmentsModel.OnPostAdditems(items);
            return RedirectToPage("/Doctor/DoctorAppoinments");
        }
    }
}
