using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;

namespace ClothingShop_TrainingTime.Pages.Ansatte_Side.Ansatte_CRUDS.Produckter_CRUD
{
    public class IndexModel : PageModel
    {
        private readonly ClothingShop_TrainingTime.Data.ClothDBContext _context;

        public IndexModel(ClothingShop_TrainingTime.Data.ClothDBContext context)
        {
            _context = context;
        }

        public IList<Produkter> Produkter { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produkter = await _context.Produkters
                .Include(p => p.Kategori).ToListAsync();
        }
    }
}
