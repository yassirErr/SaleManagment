using Microsoft.AspNetCore.Components;
using SaleManagment.Shared;
using System.Net.Http.Json;

namespace SaleManagment.Client.Service.WindowService
{
    public class WindowService : IWindowService
    {

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public WindowService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _http = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Window> Windo { get; set; }

        public async Task GetWindows()
        {
            var result = await _http.GetFromJsonAsync<List<Window>>("/api/window");

            if (result != null)
                Windo = result;
        }
        public async Task<Window> GetWindow(int id)
        {
            var result = await _http.GetFromJsonAsync<Window>($"/api/window/{id}");

            if (result != null)
                return result;
            throw new Exception("Window not found!");
        }


        public async Task CreateWindow(Window win)
        {
            var result = await _http.PostAsJsonAsync("api/window", win);
            await SetWin(result);
        }

        public async Task DeleteWindow(int id)
        {
            var result = await _http.DeleteAsync($"api/window/{id}");
            await SetWin(result);
        }

        public async Task UpdateWindow(Window win)
        {
            var result = await _http.PutAsJsonAsync($"api/window/{win.Id}", win);
            await SetWin(result);
        }

        private async Task SetWin(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Window>>();
            Windo = response;
            _navigationManager.NavigateTo("windows");
        }

    }
}
