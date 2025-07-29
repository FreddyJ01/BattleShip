// Import required namespaces for Blazor WebAssembly and the application
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1;

// Create a WebAssembly host builder with default configuration
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register the root components for the Blazor application
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClient as a scoped service for making HTTP requests
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Build and run the Blazor WebAssembly application
await builder.Build().RunAsync();
