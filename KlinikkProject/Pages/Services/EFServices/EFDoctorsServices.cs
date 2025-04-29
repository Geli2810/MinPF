using KlinikkProject.Models;
using KlinikkProject.Pages.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KlinikkProject.Pages.Services.EFServices
{
    public  class EFDoctorsServices : IEFServices<Lægerne>
    {
        private DoctorDBContext _service;
        public EFDoctorsServices(DoctorDBContext service)
        {
            _service = service;

        }
        public List<Lægerne> Services { get; set; } = new List<Lægerne>();

        public async Task GetServices()
        {
            await _service.Lægernes.ToListAsync();

        }

        public Task AddService(Lægerne service)
        {
            _service.Add(service);
            return _service.SaveChangesAsync();
        }

        public Task DeleteService(Lægerne id)
        {
            _service.Remove(id);
            return _service.SaveChangesAsync();
        }

        public Lægerne GetService(int id)
        {
            var service = Services.FirstOrDefault(p => p.Id == id);
            return service;
        }


        public void UpdateService(Lægerne service)
        {
            _service.Update(service);
            _service.SaveChanges();
        }

 
    }
}
