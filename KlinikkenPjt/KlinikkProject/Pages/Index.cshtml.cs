using KlinikkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KlinikkProject.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private DoctorDBContext _context;
    public IndexModel(ILogger<IndexModel> logger, DoctorDBContext context)
    {
        _logger = logger;
        _context = context;
    }
    public List<OurMember> OurMembers { get; set; } = new List<OurMember>();

    public List<Administrador> administradors { get; set; } = new List<Administrador>();

    public async Task OnGetAsync()
    {
        OurMembers = await _context.OurMembers.ToListAsync();
        administradors = await _context.Administradors.ToListAsync();
    }
    #region Methods
    public void OnPostLogIndMethod(string Email, string Password)
    {
        var member = _context.OurMembers.FirstOrDefault(m => m.MemberEmail == Email);
        if (Email == member?.MemberEmail && Password == member?.MemberPassword)
        {
            LogTheMembSiteModel.AddMember(member);
            Response.Redirect("/LogTheMembSite");
        }
        else
        {
            Page();
        }
    }

    public void AddMember(OurMember member)
    {
        _context.OurMembers.Add(member);
    }

    public IActionResult OnPostGetit()
    {
        return RedirectToPage("/Members/TheNewUser");
    }

    public IActionResult OnPostToAdminSite()
    {
        return RedirectToPage("/CrudFolders/TheAdministrationSite");
    }
    #endregion

}
