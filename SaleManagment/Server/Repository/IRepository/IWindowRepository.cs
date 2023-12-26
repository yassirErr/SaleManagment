using SaleManagment.Shared;

namespace SaleManagment.Server.Repository.IRepository
{
    public interface IWindowRepository : IRepository<Window>
    {
        void Update(Window obj);
    }
}
