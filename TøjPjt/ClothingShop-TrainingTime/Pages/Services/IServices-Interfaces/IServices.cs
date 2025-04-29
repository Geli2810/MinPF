namespace ClothingShop_TrainingTime.Pages.Services.IServices_Interfaces
{
    public interface IServices <T>
    {
        IEnumerable<List<T>> GetAllServices();
        IEnumerable<T> GetServiceById(int id);
        IEnumerable<T> AddService(T service);
        IEnumerable<T> UpdateService(T service);
        IEnumerable<T> DeleteService(int id);
        IEnumerable<List<T>> GetServicesByCategory(string category);
        IEnumerable<List<T>> GetServicesByPriceRange(decimal minPrice, decimal maxPrice);
        IEnumerable<List<T>> GetServicesByRating(int rating);
        IEnumerable<List<T>> GetServicesByAvailability(bool isAvailable);
    }
}
