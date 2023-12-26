using SaleManagment.Server.Data;
using SaleManagment.Server.Repository.IRepository;


namespace SaleManagment.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            Order = new OrderRepository(db);
            Window = new WindowRepository(db);
            SubElement = new SubElementRepository (db);
            _db = db;
        }
        public IOrderRepository Order { get ; set; }
        public IWindowRepository Window { get ; set; }
        public ISubElementRepository SubElement { get; set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
