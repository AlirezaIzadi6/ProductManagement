using AutoMapper;
using Moq;
using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.Create;
using Application.Interfaces;
using Application.Wrappers;
using UnitTests.Fixtures;

namespace UnitTests.Application.Features.Products;

public class ProductCommandsTest
{
    private readonly Mock<IProductRepositoryAsync> mockRepository;
    private readonly Mock<IMapper> mockMapper;
    public ProductCommandsTest()
    {
        mockRepository = new Mock<IProductRepositoryAsync>();
        mockMapper = new Mock<IMapper>();
    }

    public class CreateProductCommandTest : ProductCommandsTest
    {
        [Fact]
        public async Task WithCorrectData_CreateProduct()
        {
            var createProductCommand = ProductTestData.createProductCommandSample;
            var fakeProductWithoutId = ProductTestData.ProductSampleWithoutId;
            var fakeProductWithId = ProductTestData.ProductSample;
            var fakeProductDto = ProductTestData.ProductDtoSample;
            mockRepository.Setup(rep => rep.CreateAsync(fakeProductWithoutId))
                .ReturnsAsync(fakeProductWithId);
            mockRepository.Setup(rep => rep.IsUniqueAsync(createProductCommand.Name, createProductCommand.ProduceDate))
                .ReturnsAsync(true);
            mockMapper.Setup(m => m.Map<Product>(createProductCommand))
                .Returns(fakeProductWithoutId);
            mockMapper.Setup(m => m.Map<ProductDto>(fakeProductWithId))
                .Returns(fakeProductDto);
            var handler = new CreateProductHandler(mockRepository.Object, mockMapper.Object);

            var response = await handler.Handle(createProductCommand, new CancellationToken());

            Assert.True(response.Succeded);
            Assert.NotNull(response.Data);
            Assert.Equal(createProductCommand.Name, response.Data.Name);
        }
    }
}
