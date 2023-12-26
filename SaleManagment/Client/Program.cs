using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SaleManagment.Client;
using SaleManagment.Client.Service.OrderService;
using SaleManagment.Client.Service.SubElementService;
using SaleManagment.Client.Service.WindowService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IOrderRepository, OrderService>();
builder.Services.AddScoped<IWindowService, WindowService>();
builder.Services.AddScoped<ISubElementService, SubElementService >();
await builder.Build().RunAsync();
