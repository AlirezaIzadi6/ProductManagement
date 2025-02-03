using AutoMapper;
using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.Create;
using Application.Features.Products.Update;
using Web.DTOs;
using UnitTests.Profiles;

namespace UnitTests.Fixtures;

public class ProductTestData
{
    private Mapper mapper;

    public ProductTestData()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
        mapper = new Mapper(configuration);
    }

    private static readonly Product product1 = new Product
    {
        Id = 1,
        CreatedByUserId = "TestUser",
        Name = "Test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test@test.com",
        ManufacturePhone = "1234567890",
        IsAvailable = true,
    };

    private static readonly Product product2 = new Product
    {
        Id = 2,
        CreatedByUserId = new Guid().ToString(),
        Name = "Another test",
        ProduceDate = DateOnly.FromDateTime(DateTime.Now),
        ManufactureEmail = "test2@test.com",
        ManufacturePhone = "1112223334",
        IsAvailable = true,
    };

    public Product GetProduct1()
    {
        return product1;
    }

    public Product GetProduct2()
    {
        return product2;
    }

    public Product GetWithoutId()
    {
        return new Product
        {
            CreatedByUserId = product1.CreatedByUserId,
            Name = product1.Name,
            ProduceDate = product1.ProduceDate,
            ManufactureEmail = product1.ManufactureEmail,
            ManufacturePhone = product1.ManufacturePhone,
            IsAvailable = product1.IsAvailable,
        };
    }

    public Product GetWithoutId(Product product)
    {
        return new Product
        {
            CreatedByUserId = product.CreatedByUserId,
            Name = product.Name,
            ProduceDate = product.ProduceDate,
            ManufactureEmail = product.ManufactureEmail,
            ManufacturePhone = product.ManufacturePhone,
            IsAvailable = product.IsAvailable,
        };
    }

    public ProductDto GetDto()
    {
        return mapper.Map<ProductDto>(product1);
    }

    public ProductDto GetDto(Product product)
    {
        return mapper.Map<ProductDto>(product);
    }

    public CreateProductCommand GetCreateCommand()
    {
        return mapper.Map<CreateProductCommand>(product1);
    }

    public CreateProductCommand GetCreateCommand(Product product)
    {
        return mapper.Map<CreateProductCommand>(product);
    }

    public UpdateProductCommand GetUpdateCommand()
    {
        return mapper.Map<UpdateProductCommand>(product1);
    }

    public UpdateProductCommand GetUpdateCommand(Product product)
    {
        return mapper.Map<UpdateProductCommand>(product);
    }

    public CreateProductDto GetCreateDto()
    {
        return mapper.Map<CreateProductDto>(product1);
    }

    public CreateProductDto GetCreateDto(Product product)
    {
        return mapper.Map<CreateProductDto>(product);
    }

    public UpdateProductDto GetUpdateDto()
    {
        return mapper.Map<UpdateProductDto>(product1);
    }

    public UpdateProductDto GetUpdateDto(Product product)
    {
        return mapper.Map<UpdateProductDto>(product);
    }

    public IEnumerable<Product> GetProducts()
    {
        return new List<Product> { product1, product2 };
    }

    public IEnumerable<ProductDto> GetDtos()
    {
        return new List<ProductDto> { GetDto(product1), GetDto(product2) };
    }
}
