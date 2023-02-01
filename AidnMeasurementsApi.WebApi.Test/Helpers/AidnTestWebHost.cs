using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http.Headers;

namespace AidnMeasurementsApi.WebApi.Client.Test.Helpers;

public abstract class AidnTestWebHost<TEntryPoint> : WebApplicationFactory<TEntryPoint>
    where TEntryPoint : class
{
    private const string AuthScheme = "Test";

    private readonly List<ServiceDescriptor> _serviceDescriptors = new();
    private HttpClient? _client;

    protected HttpClient GetClient()
    {
        if (_client != null) return _client;

        _client = CreateDefaultClient();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthScheme);
        return _client;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) _client?.Dispose();
        base.Dispose(disposing);
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("CI");
        builder.ConfigureTestServices(ConfigureServices);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        foreach (var service in _serviceDescriptors)
        {
            services.Replace(service);
        }

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = AuthScheme;
            options.DefaultChallengeScheme = AuthScheme;
        }).AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(AuthScheme, _ => { });
    }

    protected void ReplaceService<T>(T instance) where T : class
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), instance));
    }
}