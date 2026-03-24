using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SelianordMCT.Web;
using SelianordMCT.Web.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Existing default HttpClient for Blazor app
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthService>();

// API HttpClient
builder.Services.AddScoped<EnquiryApiService>(sp =>
{
    var localStorage = sp.GetRequiredService<ILocalStorageService>();

    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7044/"),
        Timeout = TimeSpan.FromSeconds(30)
    };

    return new EnquiryApiService(httpClient, localStorage);
});

await builder.Build().RunAsync();