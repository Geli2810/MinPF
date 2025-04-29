using KlinikkProject.Models;
using KlinikkProject.Pages.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikkProject.Pages.Services.EFServices
{
    public class EFGenericService<T> : IEFServices<T> where T : class
    {
        private DoctorDBContext _service;
        public EFGenericService(DoctorDBContext service)
        {
            _service = service;

        }

        public List<T> Services { get; set; } = new List<T>();

        public async Task AddService(T service)
        {
            _service.Add(service);
            await _service.SaveChangesAsync();
        }

        public async Task DeleteService(T id)
        {
            _service.Remove(id);
            await _service.SaveChangesAsync();

        }

        public T GetService(int id)
        {
            var service = _service.Set<T>().Find(id);
            return service;
        }

        public async Task<List<T>> GetServices()
        {
            Services = await _service.Set<T>().ToListAsync();
            return Services;
        }

        public void UpdateService(T service)
        {
            _service.Update(service);
            _service.SaveChanges();
        }

        Task IEFServices<T>.GetServices()
        {
            return GetServices();
        }
    }
}
