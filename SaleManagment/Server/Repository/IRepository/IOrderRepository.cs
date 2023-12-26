using Microsoft.EntityFrameworkCore;
using SaleManagment.Shared;

namespace SaleManagment.Server.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
   
        void Update(Order obj);

    }
}
