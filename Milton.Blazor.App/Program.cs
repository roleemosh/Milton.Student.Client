using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Milton.Blazor.App;
using Milton.Blazor.Shared.Helpers;
using Milton.Blazor.Shared.Interfaces;
using Milton.Blazor.Shared.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPageTitleService, PageTitleService>();
builder.Services.AddSingleton<ISubjectRepo,  SubjectsRepo>();
builder.Services.AddMudServices();


await builder.Build().RunAsync();
