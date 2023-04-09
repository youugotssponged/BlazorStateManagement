using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using BlazorStateManagement;
using BlazorStateManagement.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorise(options => { options.Immediate = true;})
     .AddBootstrapProviders()
     .AddFontAwesomeIcons();

builder.Services.AddSingleton<AppStateContainer>();
builder.Services.AddSingleton<IBrowserStorageInterop, BrowserStorageInterop>();

await builder.Build().RunAsync();
