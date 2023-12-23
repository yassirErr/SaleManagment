using Microsoft.AspNetCore.Components;
using SaleManagment.Shared;
using System.Net.Http.Json;

namespace SaleManagment.Client.Service.SubElementService
{
    public class SubElementService : ISubElementService
    {

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public SubElementService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _http = httpClient;
            _navigationManager = navigationManager;
        }

        public List<SubElement> SubEl { get; set; }

        public async Task GetSubElements()
        {
            var result = await _http.GetFromJsonAsync<List<SubElement>>("/api/subElement");

            if (result != null)
                SubEl = result;
        }
        public async Task<SubElement> GetSubElement(int id)
        {
            var result = await _http.GetFromJsonAsync<SubElement>($"/api/subElement/{id}");

            if (result != null)
                return result;
            throw new Exception("SubElement not found!");
        }


        public async Task CreateSubElement(SubElement sb)
        {
            var result = await _http.PostAsJsonAsync("api/subElement", sb);
            await SetSub(result);
        }

        public async Task DeleteSubElement(int id)
        {
            var result = await _http.DeleteAsync($"api/subElement/{id}");
            await SetSub(result);
        }

        public async Task UpdateSubElement(SubElement sb)
        {
            var result = await _http.PutAsJsonAsync($"api/subElement/{sb.Id}", sb);
            await SetSub(result);
        }

        private async Task SetSub(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SubElement>>();
            SubEl = response;
            _navigationManager.NavigateTo("subElements");
        }

    }
}
