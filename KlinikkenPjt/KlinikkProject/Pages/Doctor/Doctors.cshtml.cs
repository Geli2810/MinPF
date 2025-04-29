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

        public List<L�gerne> DoctorList { get; set; } = new List<L�gerne>();
        public async Task OnGetAsync()
        {
            DoctorList = await _context.L�gernes.ToListAsync();
        }

        public IActionResult OnPostBestilTid(int id)
        {
            List<Tider> items = _context.L�gernes
                .Where(x => x.Id == id)
                .SelectMany(x => x.Tiders).ToList();


            DoctorAppoinmentsModel.OnPostAdditems(items);
            return RedirectToPage("/Doctor/DoctorAppoinments");
        }
    }
}
