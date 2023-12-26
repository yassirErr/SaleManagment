using SaleManagment.Shared;

namespace SaleManagment.Server.Repository.IRepository
{
    public interface ISubElementRepository : IRepository<SubElement>
    {
        void Update(SubElement obj);
    }
}
