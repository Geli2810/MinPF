using KlinikkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlinikkProject.Pages.Members
{
    public class OurMembersModel : PageModel
    {
        private DoctorDBContext doctorDBContext;
        public OurMembersModel(DoctorDBContext doctorDBContext)
        {
            this.doctorDBContext = doctorDBContext;
            
        }
        public List<OurMember> ListOfMembers { get; set; } = new List<OurMember>();
        public void OnGet()
        {
            ListOfMembers = doctorDBContext.OurMembers.ToList();

        }
    }
}
