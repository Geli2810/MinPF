using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;
using ClothingShop_TrainingTime.Pages.Ansatte_Side.Ansatte_CRUDS.Produckter_CRUD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClothingShop_TrainingTime.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private ClothDBContext dBContext;
    public IndexModel(ILogger<IndexModel> logger, ClothDBContext dBContext)
    {
        _logger = logger;
        this.dBContext = dBContext;
    }
    public List<Annoncer> Produckters { get; set; } = new List<Annoncer>();

    public async Task OnGet()
    {
        var today = DateOnly.FromDateTime(DateTime.Today); 

        Produckters = await dBContext.Annoncers
            .Where(a => a.IsAktiv == true &&
                        a.StartDato <= today && 
                        a.SlutDato >= today)   
            .ToListAsync();
        TheUpcomingMonth = await GetTheUpcomingMonth(); 
    }

    public List<Annoncer> TheUpcomingMonth { get; set; } = new List<Annoncer>();


    public async Task<List<Annoncer>> GetTheUpcomingMonth()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var nextMonth = today.AddMonths(1);

        var startOfNextMonth = new DateOnly(nextMonth.Year, nextMonth.Month, 1);
        var startOfFollowingMonth = startOfNextMonth.AddMonths(1);

        return await dBContext.Annoncers
            .Where(a => a.StartDato != null &&
                        a.StartDato >= startOfNextMonth &&
                        a.StartDato < startOfFollowingMonth)
            .ToListAsync();
    }

}
