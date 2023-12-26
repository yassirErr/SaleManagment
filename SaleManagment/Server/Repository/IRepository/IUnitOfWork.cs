namespace SaleManagment.Server.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; set; }
        IWindowRepository Window { get; set; }
        ISubElementRepository SubElement { get; set; }
        void Save();
    }
}
