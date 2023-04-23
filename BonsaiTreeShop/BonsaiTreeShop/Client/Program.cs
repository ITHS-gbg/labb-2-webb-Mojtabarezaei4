using Blazored.LocalStorage;
using BonsaiTreeShop.Client;
using BonsaiTreeShop.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BonsaiTreeShop.ServerAPI", 
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.
    AddHttpClient("public", 
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.
    AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient("BonsaiTreeShop"));


// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BonsaiTreeShop.ServerAPI"));
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddApiAuthorization();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
