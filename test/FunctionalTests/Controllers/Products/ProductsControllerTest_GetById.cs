using Application.DTOs;
using UnitTests.Fixtures;
using UnitTests.Helpers;

namespace FunctionalTests.Controllers.Products;

[Collection("MyTests")]
public class ProductsControllerTest_GetById : ProductsControllerTest
{
    private readonly string requestUrl = "/api/products";
    public ProductsControllerTest_GetById(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task ReturnRequestedProductById()
    {
        var client = GetNewClient();
        var urlWithPathParam = $"{requestUrl}/1";

        var response = await client.GetAsync(urlWithPathParam);

        response.EnsureSuccessStatusCode();

        var productDto = await JsonHelper.ParseResponse<ProductDto>(response.Content);
        Assert.NotNull(productDto);
        Assert.Equal(1, productDto.Id);
    }

    [Fact]
    public async Task ReturnNotFoundForNotExistingId()
    {
        var client = GetNewClient();
        var urlWithPathParam = $"{requestUrl}/1001";

        var response = await client.GetAsync(urlWithPathParam);

        Assert.Equal("NotFound", response.StatusCode.ToString());
    }
}
