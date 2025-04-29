using KlinikkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KlinikkProject.Pages
{
    public class LogTheMembSiteModel : PageModel
    {
        private readonly DoctorDBContext doctorDBContext;
        public LogTheMembSiteModel(DoctorDBContext doctorDBContext)
        {
            this.doctorDBContext = doctorDBContext;
            
        }
        public static List<OurMember> ourMembers = new List<OurMember>();

        public static void AddMember(OurMember member)
        {
            ourMembers.Add(member);
        }

        public static List<OurMember> GetMembers()
        {
            return ourMembers;
        }



        public List<OurMember> OurMembers { get; set; } = new List<OurMember>();
        public void OnGet()
        {
            OurMembers = doctorDBContext.OurMembers.ToList();
        }
    }
}
