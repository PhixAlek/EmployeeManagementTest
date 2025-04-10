using System.Net;
using Polly;
using Polly.Extensions.Http;
using EmployeeManagementTest.Business.Interfaces;
using EmployeeManagementTest.Business.Services;
using EmployeeManagementTest.DataAccess.Interfaces;
using EmployeeManagementTest.DataAccess.Clients;

var builder = WebApplication.CreateBuilder(args);

// Dependency injection
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Configure HttpClient with Polly retry policy
builder.Services.AddHttpClient<IEmployeeApiClient, EmployeeApiClient>()
    .AddPolicyHandler(GetRetryPolicy()); // Polly integration

builder.Services.AddControllersWithViews(); // Enables API + Razor Views

var app = builder.Build();

// Middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// MVC route configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/// <summary>
/// Returns an HTTP retry policy with exponential backoff for transient failures and rate limiting.
/// </summary>
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError() // Handles 5xx and 408 errors
        .OrResult(msg => msg.StatusCode == HttpStatusCode.TooManyRequests)
        .WaitAndRetryAsync(
            retryCount: 3,
            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) // 2s, 4s, 8s
        );
}
