using Xunit;

namespace FunctionalTests.Controllers;

public class BaseControllersTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public BaseControllersTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    public HttpClient GetNewClient()
    {
        var newClient = _factory.WithWebHostBuilder(builder =>
        {
            _factory.CustomConfigureServices(builder);
        });

        return newClient;
    }
}
