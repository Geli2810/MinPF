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
        public List<L�gerne> L�gerne { get; set; } = new List<L�gerne>();
        public List<Tider> Tider { get; set; } = new List<Tider>();
        public void OnGet()
        {
            L�gerne = _context.L�gernes.ToList();
            Tider = _context.Tiders.ToList(); 
        }
    }
}
