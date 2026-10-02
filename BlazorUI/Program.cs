using API.Clients;
using BlazorUI.Auth;
using BlazorUI.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Authorization.Policy;


var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Servicios de Seguridad EXACTOS para LocalStorage (Acá volvemos a usar solo Core)
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, PassThroughAuthorizationResultHandler>();

// 3. Registrar el almacenamiento local cifrado de Blazor y Providers
builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<BlazorAuthService>();
builder.Services.AddScoped<IAuthService>(sp => sp.GetRequiredService<BlazorAuthService>());

// 4. Configuración de la API Base URL
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5263";
BaseApiClient.BaseUrl = apiBaseUrl;

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
});

// 5. Registrar TODOS los API Clients
builder.Services.AddScoped<AuthApiClient>();
builder.Services.AddScoped<ConsultaApiClient>();
builder.Services.AddScoped<EspecialidadApiClient>();
builder.Services.AddScoped<FacturaApiClient>();
builder.Services.AddScoped<InsumoApiClient>();
builder.Services.AddScoped<MultaApiClient>();
builder.Services.AddScoped<OdontologoApiClient>();
builder.Services.AddScoped<PacienteApiClient>();
builder.Services.AddScoped<ReportesApiClient>();
builder.Services.AddScoped<TurnoApiClient>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery(); 

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();