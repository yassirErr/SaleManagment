using SaleManagment.Shared;

namespace SaleManagment.Client.Service.WindowService
{
    public interface IWindowService
    {
        List<Window> Windo { get; set; }
        Task GetWindows();
        Task<Window> GetWindow(int id);
        Task CreateWindow(Window Win);
        Task UpdateWindow(Window Win);
        Task DeleteWindow(int id);
    }
}
