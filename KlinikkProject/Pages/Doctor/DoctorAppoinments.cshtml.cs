using KlinikkProject.Models;
using KlinikkProject.Pages.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KlinikkProject.Pages.Doctor
{
    public class DoctorAppoinmentsModel : PageModel
    {
        public static List<Tider> Tider = new List<Tider>();

        private DoctorDBContext dbContext;
        public List<Tider> TheRightItems = new List<Tider>();

        public DoctorAppoinmentsModel(DoctorDBContext doctorDBContext)
        {
            dbContext = doctorDBContext;
        }
        public async Task OnGetasync()
        {
            TheRightItems = await dbContext.Tiders.ToListAsync();
        }

        public static List<Tider> OnPostAdditems(List<Tider> tider)
        {
            Tider.AddRange(tider);
            return Tider;
        }

        public IActionResult OnPostBekræftelse(Tider tider)
        {
            Tider? theItem = dbContext.Tiders.FirstOrDefault(p => p.Id == tider.Id);

            BekræftelseAfMailModel.OnPostAddTid(theItem);
            

            return RedirectToPage("BekræftelseAfMail");
        }
    }
}
