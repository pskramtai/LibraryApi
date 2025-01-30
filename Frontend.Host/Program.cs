using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend.Host;
using Frontend.Host.Clients;
using Frontend.Host.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddScoped<IBookService, BookService>()
    .AddScoped<StateContainer>()
    .AddRefitClient<IBookApiClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("http://localhost:5206"));

await builder.Build().RunAsync();