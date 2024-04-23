using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAuth.Client;
using BlazorAuth.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorAuth.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5010/") });

builder.Services.AddScoped(typeof(IBaseDataService<>), typeof(BaseDataService<>));
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddTransient<IAuthDataService, AuthDataService>();
builder.Services.AddTransient<IBookDataService, BookDataService>();
builder.Services.AddTransient<IUserDataService, UserDataService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();

await builder.Build().RunAsync();
