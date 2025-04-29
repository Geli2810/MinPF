using KlinikkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlinikkProject.Pages.CrudFolders
{
    public class AdministrationLogInModel : PageModel
    {
        private DoctorDBContext _context;
        public AdministrationLogInModel(DoctorDBContext context)
        {
            _context = context;
        }
        public List<Administrador> administradors { get; set; } = new List<Administrador>();
        public void OnGet()
        {
            administradors = _context.Administradors.ToList();

        }
    }
}
