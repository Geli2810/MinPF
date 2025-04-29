using ClothingShop_TrainingTime.Data;
using ClothingShop_TrainingTime.Models;

namespace ClothingShop_TrainingTime.Pages.Services.Produkt_Services
{
    public class ProduktServices : IServices_Interfaces.IServices<Produkter>
    {
        private readonly ClothDBContext _context;

        public ProduktServices(ClothDBContext clothDBContext) 
        {
            _context = clothDBContext;
        
        }
        public IEnumerable<Produkter> AddService(Produkter service)
        {
            _context.Produkters.Add(service);
            _context.SaveChanges();
            return _context.Produkters;
        }

        public IEnumerable<Produkter> DeleteService(int id)
        {
            var produkt = _context.Produkters.Find(id);
            if (produkt != null)
            {
                _context.Produkters.Remove(produkt);
                _context.SaveChanges();
            }
            return _context.Produkters;
        }

        public IEnumerable<List<Produkter>> GetAllServices()
        {
            return (IEnumerable<List<Produkter>>)_context.Produkters.ToList();
        }

        public IEnumerable<Produkter> GetServiceById(int id)
        {
            if (id > 0)
            {
                return _context.Produkters.Where(x => x.ProduktId == id);
            }
            return null;
        }

        public IEnumerable<List<Produkter>> GetServicesByAvailability(bool isAvailable)
        {
           return null;
        }

        public IEnumerable<List<Produkter>> GetServicesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<List<Produkter>> GetServicesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<List<Produkter>> GetServicesByRating(int rating)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produkter> UpdateService(Produkter service)
        {
            throw new NotImplementedException();
        }
    }
}
