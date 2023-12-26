
using SaleManagment.Server.Data;
using SaleManagment.Server.Repository.IRepository;
using SaleManagment.Shared;

namespace SaleManagment.Server.Repository
{
    public class WindowRepository: Repository<Window>, IWindowRepository
    {
        private readonly AppDbContext _db;
        public WindowRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Window obj)
        {
            _db.Windows.Update(obj);
        }

    }
}
