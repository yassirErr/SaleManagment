using SaleManagment.Shared;

namespace SaleManagment.Client.Service.SubElementService
{
    public interface ISubElementService
    {
        List<SubElement> SubEl { get; set; }
        Task GetSubElements();
        Task<SubElement> GetSubElement(int id);
        Task CreateSubElement(SubElement Win);
        Task UpdateSubElement(SubElement Win);
        Task DeleteSubElement(int id);
    }
}
