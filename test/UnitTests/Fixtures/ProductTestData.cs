using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.Create;

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

    public static readonly Product ProductSampleWithoutId = new Product
    {
        CreatedByUserId = ProductSample.CreatedByUserId,
        Name = "Test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test@test.com",
        ManufacturePhone = "1234567890",
        IsAvailable = true,
    };

    public static readonly ProductDto ProductDtoSample = new ProductDto
    {
        Id = 1,
        CreatedByUserId = ProductSample.CreatedByUserId,
        Name = "Test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test@test.com",
        ManufacturePhone = "1234567890",
        IsAvailable = true,
    };

    public static readonly CreateProductCommand createProductCommandSample = new CreateProductCommand
    {
        CreatedByUserId = ProductSample.CreatedByUserId,
        Name = "Test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test@test.com",
        ManufacturePhone = "1234567890",
        IsAvailable = true,
    };

    public static readonly Product ProductSample2 = new Product
    {
        Id = 2,
        CreatedByUserId = new Guid().ToString(),
        Name = "Another test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test2@test.com",
        ManufacturePhone = "1112223334",
        IsAvailable = true,
    };


    public static readonly ProductDto ProductDtoSample2 = new ProductDto
    {
        Id = 2,
        CreatedByUserId = new Guid().ToString(),
        Name = "Another test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test2@test.com",
        ManufacturePhone = "1112223334",
        IsAvailable = true,
    };

    public static readonly IEnumerable<Product> ProductListSample = new List<Product> { ProductSample, ProductSample2 };
    public static readonly IEnumerable<ProductDto> ProductDtoListSample = new List<ProductDto> { ProductDtoSample, ProductDtoSample2 };
}
