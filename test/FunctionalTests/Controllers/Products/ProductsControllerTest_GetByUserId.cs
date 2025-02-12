using Application.DTOs;
using UnitTests.Fixtures;
using UnitTests.Helpers;

namespace FunctionalTests.Controllers.Products;

[Collection("MyTests")]
public class ProductsControllerTest_GetByUserId : ProductsControllerTest
{
    private readonly string requestUrl = "/api/products";
    public ProductsControllerTest_GetByUserId(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task ReturnProductsCreatedBySpecifiedUser()
    {
        var client = GetNewClient();
        var userTestData = new UserTestData();
        var testUser1 = userTestData.GetUser1();
        var userId = testUser1.Id;
        var urlWithQueryParam = $"{requestUrl}?creator={userId}";

        var response = await client.GetAsync(urlWithQueryParam);

        var productDtos = await JsonHelper.ParseResponse<List<ProductDto>>(response.Content);
        Assert.Equal(3, productDtos.Count);
    }
}
