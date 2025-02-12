using System.Net.Http.Headers;
using Application.DTOs;
using Web.DTOs;
using UnitTests.Fixtures;
using UnitTests.Helpers;
using FunctionalTests.Helpers;

namespace FunctionalTests.Controllers.Products;

[Collection("MyTests")]
public class ProductsControllerTest_Update : ProductsControllerTest
{
    private readonly HttpClient client;
    private readonly CreateProductDto request;
    private readonly string requestUrl = "/api/products/1";

    public ProductsControllerTest_Update(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    {
        request = productTestData.GetUpdateDto();
        var userTestData = new UserTestData();
        var testUser1 = userTestData.GetUser1();
        client = GetNewClient();

        var jwtToken = Login.GetBearerToken(client, testUser1).Result;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
    }

    [Fact]
    public async Task UpdateRequestedProduct()
    {
        request.ManufactureEmail = "updatedemail@test.com";
        var content = JsonHelper.GetJsonRequest(request);

        var response1 = await client.PutAsync(requestUrl, content);

        response1.EnsureSuccessStatusCode();

        var response2 = await client.GetAsync(requestUrl);
        var productDto = await JsonHelper.ParseResponse<ProductDto>(response2.Content);

        Assert.Equal("updatedemail@test.com", productDto.ManufactureEmail);
    }
}
