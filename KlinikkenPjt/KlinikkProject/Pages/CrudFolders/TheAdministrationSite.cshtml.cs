using KlinikkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlinikkProject.Pages.CrudFolders
{
    public class TheAdministrationSiteModel : PageModel
    {
        private DoctorDBContext _context;
        public TheAdministrationSiteModel(DoctorDBContext context)
        {
            _context = context;
            
        }
        public List<Lægerne> Lægerne { get; set; } = new List<Lægerne>();
        public List<Tider> Tider { get; set; } = new List<Tider>();
        public void OnGet()
        {
            Lægerne = _context.Lægernes.ToList();
            Tider = _context.Tiders.ToList(); 
        }
    }
}
