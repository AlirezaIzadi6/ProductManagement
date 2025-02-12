using Application.DTOs;
using UnitTests.Helpers;

namespace FunctionalTests.Controllers.Products;

[Collection("MyTests")]
public class ProductsControllerTest_GetAll : ProductsControllerTest
{
    private readonly string requestUrl = "/api/products";
    public ProductsControllerTest_GetAll(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task ReturnAllProducts()
    {
        var client = GetNewClient();

        var response = await client.GetAsync(requestUrl);

        var productDtos = await JsonHelper.ParseResponse<List<ProductDto>>(response.Content);
        Assert.Equal(4, productDtos.Count);
    }
}
