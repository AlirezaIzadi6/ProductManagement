using System.Net.Http.Headers;
using Application.DTOs;
using Web.DTOs;
using UnitTests.Fixtures;
using UnitTests.Helpers;
using FunctionalTests.Helpers;

namespace FunctionalTests.Controllers.Products;

[Collection("MyTests")]
public class ProductsControllerTest_Create : ProductsControllerTest
{
    private readonly HttpClient client;
    private readonly CreateProductDto request;
    private readonly string requestUrl = "/api/products";

    public ProductsControllerTest_Create(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    {
        request = productTestData.GetCreateDto();
        var userTestData = new UserTestData();
        var testUser1 = userTestData.GetUser1();
        client = GetNewClient();

        var jwtToken = Login.GetBearerToken(client, testUser1).Result;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
    }

    [Fact]
    public async Task CreateProduct_ReturnCreatedProduct()
    {
        var content = JsonHelper.GetJsonRequest(request);

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

    [Fact]
    public async Task CreateProduct_FailIfNotLoggedIn()
    {
        client.DefaultRequestHeaders.Authorization = null;
        var content = JsonHelper.GetJsonRequest(request);

        var response = await client.PostAsync(requestUrl, content);

        Assert.Equal("Unauthorized", response.StatusCode.ToString());
    }

    [Fact]
    public async Task CreateProduct_FailIfProductDateIsInFuture()
    {
        var tomorrow = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        request.ProduceDate = tomorrow;

        var content = JsonHelper.GetJsonRequest(request);

        var response = await client.PostAsync(requestUrl, content);

        Assert.Equal("BadRequest", response.StatusCode.ToString());
    }

    [Fact]
    public async Task CreateProduct_FailIfNameIsTooLong()
    {
        var longName = new string('a', 101);
        request.Name = longName;

        var content = JsonHelper.GetJsonRequest(request);

        var response = await client.PostAsync(requestUrl, content);

        Assert.Equal("BadRequest", response.StatusCode.ToString());
    }

    [Fact]
    public async Task CreateProduct_FailIfNameIsEmpty()
    {
        var longName = string.Empty;
        request.Name = longName;

        var content = JsonHelper.GetJsonRequest(request);

        var response = await client.PostAsync(requestUrl, content);

        Assert.Equal("BadRequest", response.StatusCode.ToString());
    }

    [Fact]
    public async Task CreateProduct_FailIfEmailIsInvalid()
    {
        var invalidEmail = "invalidemail@";
        request.ManufactureEmail = invalidEmail;

        var content = JsonHelper.GetJsonRequest(request);

        var response = await client.PostAsync(requestUrl, content);

        Assert.Equal("BadRequest", response.StatusCode.ToString());
    }
}
