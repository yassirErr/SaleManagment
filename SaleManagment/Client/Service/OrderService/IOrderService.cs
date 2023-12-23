using SaleManagment.Shared;

namespace SaleManagment.Client.Service.OrderService
{
    public interface IOrderService
    {
        List<Order> Ords { get; set; }


        Task GetOrders();


        Task<Order> GetOrder(int id);
        Task CreateOrder(Order Ord);
        Task UpdateOrder(Order Ord);
        Task DeleteOrder(int id);
    }
}
