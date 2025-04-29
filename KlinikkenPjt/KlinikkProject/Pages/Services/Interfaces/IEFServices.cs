namespace KlinikkProject.Pages.Services.Interfaces
{
    public interface IEFServices<T>
    {
        Task AddService(T service);
        Task DeleteService(T id);
        T GetService(int id);
        Task GetServices();
        void UpdateService(T service);
    }
}
