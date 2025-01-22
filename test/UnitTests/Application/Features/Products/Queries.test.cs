using Moq;
using AutoMapper;
using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.get;
using Application.Interfaces;
using UnitTests.Fixtures;

namespace UnitTests.Application.Features.Products;

public class ProductQueriesTest
{
    private Mock<IProductRepositoryAsync> mockRepository;
    private Mock<IMapper> mockMapper;

    public ProductQueriesTest()
    {
        mockRepository = new Mock<IProductRepositoryAsync>();
        mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Get_WithExistingId_ReturnProduct()
    {
        var fakeProduct = ProductTestData.ProductSample;
        var fakeProductDto = ProductTestData.ProductDtoSample;
        int productId = fakeProduct.Id;

        mockRepository.Setup(rep => rep.GetByIdAsync(productId))
            .ReturnsAsync(fakeProduct);
        mockMapper.Setup(m => m.Map<ProductDto>(fakeProduct))
            .Returns(fakeProductDto);
        var handler = new GetProductByIdHandler(mockRepository.Object, mockMapper.Object);

        var query = new GetProductByIdQuery(productId);
        var result = await handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(productId, result.Data.Id);
    }
}
