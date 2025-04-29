using KlinikkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KlinikkProject.Pages.Doctor
{
    public class BekræftelseAfMailModel : PageModel
    {
        public DoctorDBContext _doctorDBContext;
        public static List<Tider> GetTiders { get; set; } = new List<Tider>();

        public BekræftelseAfMailModel(DoctorDBContext doctorDBContext)
        {
            _doctorDBContext = doctorDBContext;
            
        }
        List<Tider> tiders = new List<Tider>();
        public async Task OnGet()
        {
            tiders = await _doctorDBContext.Tiders.ToListAsync();
        }

        public static void OnPostAddTid(Tider tider) 
        {
            GetTiders.Add(tider);
        }

        public IActionResult OnPostSendEmail(string toEmail)
        {

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("gekija29@gmail.com"); 
                mail.To.Add(toEmail); 
                mail.Subject = "Mail Bekræftelse";
                mail.Body = $"Kære {@toEmail}, Tak for din tidsbestilling. Vi bekræfter hermed din aftale:\r\n\r\nHvis du har spørgsmål eller har brug for at ændre din tid, er du velkommen til at kontakte os på vores email som er: gekija29@gmail.com.\r\n\r\nVi ser frem til at se dig!";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("gekija29@gmail.com", "lmjl yfkl ebbb sgbg"),
                    EnableSsl = true
                };


            smtp.Send(mail);

            return RedirectToPage("EmailBeskeden");

        }



    }
}
