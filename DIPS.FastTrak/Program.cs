using DIPS.FastTrak;
using DIPS.FastTrak.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IPopulationsService, PopulationsService>();
builder.Services.AddSingleton<IProblemsService, ProblemsService>();
builder.Services.AddSingleton<IClinFormsService, ClinFormsService>();
builder.Services.AddSingleton<IAutorization, OAuth2Service>();
builder.Services.AddSingleton<IGlobalSearch, GlobalSearch>();
builder.Services.AddSingleton<IUiService, UiService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<INotificationsService, NotificationsService>();

await builder.Build().RunAsync();
