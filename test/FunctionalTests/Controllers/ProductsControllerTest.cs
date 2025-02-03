using System.Net.Http.Headers;
using Application.DTOs;
using Web.DTOs;
using UnitTests.Fixtures;
using FunctionalTests.Helpers;

namespace FunctionalTests.Controllers;

[Collection("MyTests")]
public class ProductsControllerTest : BaseControllersTest
{
    private readonly ProductTestData productTestData;
    private readonly string jwtToken;
    public ProductsControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
        productTestData = new ProductTestData();
        var userTestData = new UserTestData();
        var testUser1 = userTestData.GetUser1();
        var client = GetNewClient();

        jwtToken = Login.GetBearerToken(client, testUser1).Result;
    }

    [Fact]
    public async Task CreateProduct_ReturnCreatedProduct()
    {
        var client = GetNewClient();

        var request = productTestData.GetCreateDto();
        var content = JsonHelper.GetJsonRequest(request);
        string requestUrl = "/api/products";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response1 = await client.PostAsync(requestUrl, content);

        response1.EnsureSuccessStatusCode();

        var createdProductDto = await JsonHelper.ParseResponse<ProductDto>(response1.Content);

        Assert.Equal("OK", response1.StatusCode.ToString());
        Assert.Equal(createdProductDto.Name, request.Name);

        var response2 = await client.GetAsync($"/api/products/{createdProductDto.Id}");
        response2.EnsureSuccessStatusCode();
        var retrievedProductDto = await JsonHelper.ParseResponse<ProductDto>(response2.Content);

        Assert.Equal(request.Name, retrievedProductDto.Name);
    }
}
