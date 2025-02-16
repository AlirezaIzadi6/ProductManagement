using Moq;
using AutoMapper;
using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.get;
using Application.Features.Products.GetAll;
using Application.Interfaces;
using Application.Wrappers;
using UnitTests.Fixtures;

namespace UnitTests.Application.Features.Products;

public class ProductQueriesTest
{
    private Mock<IProductRepositoryAsync> mockRepository;
    private Mock<IMapper> mockMapper;
    private ProductTestData testData;

    public ProductQueriesTest()
    {
        mockRepository = new Mock<IProductRepositoryAsync>();
        mockMapper = new Mock<IMapper>();
        testData = new ProductTestData();
    }

    [Fact]
    public async Task Get_WithExistingId_ReturnProduct()
    {
        var fakeProduct = testData.GetProduct1();
        var fakeProductDto = testData.GetDto(fakeProduct);
        int productId = fakeProduct.Id;

        mockRepository.Setup(rep => rep.GetByIdAsync(productId))
            .ReturnsAsync(fakeProduct);
        mockMapper.Setup(m => m.Map<ProductDto>(fakeProduct))
            .Returns(fakeProductDto);
        var handler = new GetProductByIdHandler(mockRepository.Object, mockMapper.Object);

        var query = new GetProductByIdQuery(productId);
        var result = await handler.Handle(query, new CancellationToken());

        Assert.NotNull(result.Data);
        Assert.True(result.Succeded);
        Assert.Equal(productId, result.Data.Id);
    }

    [Fact]
    public async Task Get_WithNonExistingId_ReturnError()
    {
        int nonExistingId = 0;
        mockRepository.Setup(rep => rep.GetByIdAsync(nonExistingId))
            .ReturnsAsync((Product?)null);
        var handler = new GetProductByIdHandler(mockRepository.Object, mockMapper.Object);

        var query = new GetProductByIdQuery(nonExistingId);
        var response = await handler.Handle(query, new CancellationToken());

        Assert.False(response.Succeded);
        Assert.NotNull(response.Message);
    }

    [Fact]
    public async Task GetAll_ReturnAllProducts()
    {
        var fakeProducts = testData.GetProducts();
        var fakeProductDtos = testData.GetDtos();

        mockRepository.Setup(rep => rep.ListAsync())
            .ReturnsAsync(fakeProducts);
        mockMapper.Setup(m => m.Map<IEnumerable<ProductDto>>(fakeProducts))
            .Returns(fakeProductDtos);
        var handler = new GetAllProductsHandler(mockRepository.Object, mockMapper.Object);

        var query = new GetAllProductsQuery();
        var response = await handler.Handle(query, new CancellationToken());

        Assert.True(response.Succeded);
        Assert.NotNull(response.Data);
        Assert.Equal(fakeProductDtos.Count(), response.Data.Count());
        Assert.Equal(fakeProductDtos.First().Id, response.Data.First().Id);
    }

    [Fact]
    public async Task GetByUserId_ReturnProducts()
    {
        var fakeProducts = testData.GetProducts();
        var fakeProductDtos = testData.GetDtos();
        var creatorUserId = fakeProducts.First().CreatedByUserId;

        mockRepository.Setup(rep => rep.GetProductsByCreatorAsync(creatorUserId))
            .ReturnsAsync(fakeProducts);
        mockMapper.Setup(m => m.Map<IEnumerable<ProductDto>>(fakeProducts))
            .Returns(fakeProductDtos);
        var handler = new GetAllProductsHandler(mockRepository.Object, mockMapper.Object);

        var query = new GetAllProductsQuery { CreatedByUserId = creatorUserId };
        var response = await handler.Handle(query, new CancellationToken());

        Assert.True(response.Succeded);
        Assert.NotNull(response.Data);
        Assert.Equal(fakeProductDtos.Count(), response.Data.Count());
        Assert.Equal(fakeProductDtos.First().Id, response.Data.First().Id);
    }
}
