using SaleManagment.Server.Data;
using SaleManagment.Server.Repository;
using SaleManagment.Server.Repository.IRepository;
using SaleManagment.Shared;

namespace SaleManagment.Server.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Order obj)
        {
            _db.Orders.Update(obj);
        }
    }
}
