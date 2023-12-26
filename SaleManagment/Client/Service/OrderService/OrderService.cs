using Microsoft.AspNetCore.Components;
using SaleManagment.Shared;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace SaleManagment.Client.Service.OrderService
{
    public class OrderService : IOrderRepository
    {

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public OrderService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _http = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Order> Ords { get; set; }


        public async Task GetOrders()
        {
            var result = await _http.GetFromJsonAsync<List<Order>>("/api/order");

            if (result != null)
                Ords = result;
        }


        public async Task<Order> GetOrder(int id)
        {
            var result = await _http.GetFromJsonAsync<Order>($"/api/order/{id}");

            if (result != null)
                return result;
            throw new Exception("order not found!");
        }



        public async Task CreateOrder(Order ord)
        {
            var result = await _http.PostAsJsonAsync("api/order", ord);
            await SetOrd(result);
        }

        public async Task DeleteOrder(int id)
        {
            var result = await _http.DeleteAsync($"api/order/{id}");
            await SetOrd(result);
        }

        public async Task UpdateOrder(Order ord)
        {
            var result = await _http.PutAsJsonAsync($"api/order/{ord.Id}", ord);
            await SetOrd(result);
        }

        private async Task SetOrd(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Order>>();
            Ords = response;
            _navigationManager.NavigateTo("orders");
        }
    }
}
