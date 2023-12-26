using SaleManagment.Server.Data;
using SaleManagment.Server.Repository.IRepository;
using SaleManagment.Shared;

namespace SaleManagment.Server.Repository
{
    public class SubElementRepository : Repository<SubElement>, ISubElementRepository
    {
        private readonly AppDbContext _db;

        public SubElementRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SubElement obj)
        {
         _db.SubElements.Update(obj);
        }

    }
}
