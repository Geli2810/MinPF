using KlinikkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace KlinikkProject.Pages.Members
{
   
    public class TheNewUserModel : PageModel
    {
        private DoctorDBContext doctorDBContext;
        public TheNewUserModel(DoctorDBContext doctorDBContext)
        {
            this.doctorDBContext = doctorDBContext;
        }

        [BindProperty]
        public OurMember member { get; set; } = default!;
        public List<OurMember> ourMembers { get; set; } = new List<OurMember>();
        public void OnGet()
        {
           ourMembers = doctorDBContext.OurMembers.ToList();
            
        }

        public IActionResult OnPostTheNewUser(OurMember member)
        {
            if (member != null)
            {
                member.LægerneId = doctorDBContext.Lægernes.First().Id;
                doctorDBContext.OurMembers.Add(member);
                doctorDBContext.SaveChanges();
                LogTheMembSiteModel.AddMember(member); 

                return RedirectToPage("/Members/LogTheMembSite");
            }
            else
            {
                return Page();
            }
        }

    }
}
