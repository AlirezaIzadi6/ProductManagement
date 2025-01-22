using Domain.Entities;
using Application.DTOs;

namespace UnitTests.Fixtures;

public static class ProductTestData
{
    public static readonly Product ProductSample = new Product
    {
        Id = 1,
        CreatedByUserId = new Guid().ToString(),
        Name = "Test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test@test.com",
        ManufacturePhone = "1234567890",
        IsAvailable = true,
    };

    public static readonly ProductDto ProductDtoSample = new ProductDto
    {
        Id = 1,
        CreatedByUserId = new Guid().ToString(),
        Name = "Test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test@test.com",
        ManufacturePhone = "1234567890",
        IsAvailable = true,
    };
}
