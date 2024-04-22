using BlazorApp.Shell.Components;
using Piral.Blazor.Orchestrator;
using Piral.Blazor.Orchestrator.Loader;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Important - an `HttpClient` needs to be present for the MfDiscoveryLoaderService - for
// other services it might not be needed; so you can regard this as optional
builder.Services.AddHttpClient();
// Add DI services
builder.Services.AddMicrofrontends<MfDiscoveryLoaderService>();

// Configure container
builder.Host.UseMicrofrontendContainers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Use middleware
app.UseMicrofrontends();

app.MapMicrofrontends<App>();

app.Run();
