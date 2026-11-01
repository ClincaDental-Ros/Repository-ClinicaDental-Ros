using API.Clients;
using API.Auth.Blazor.Server;
using Blazor.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, PassThroughAuthorizationResultHandler>();


builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<BlazorServerAuthService>();
builder.Services.AddScoped<IAuthService>(sp => sp.GetRequiredService<BlazorServerAuthService>());


var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5263";
BaseApiClient.BaseUrl = apiBaseUrl;

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
});

builder.Services.AddScoped<AuthApiClient>();
builder.Services.AddScoped<ObraSocialApiClient>();
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
