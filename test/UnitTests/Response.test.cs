using Domain.Entities;
using Application.Wrappers;

namespace UnitTests;

public class ResponseTest
{
    [Fact]
    public void CreateResponseWithData_ReturnsData()
    {
        var product = new Product
        {
            Id = 1,
            CreatedByUserId = new Guid().ToString(),
            Name = "Test",
            ProduceDate = DateOnly.FromDateTime(DateTime.Now),
            ManufactureEmail = "test@example.com",
            ManufacturePhone = "1234567890",
            IsAvailable = true
        };
        var response = new Response<Product>(product);
        Assert.Equal(true, response.Succeded);
        Assert.NotNull(response.Data);
        Assert.Equal(1, response.Data.Id);
    }
}
