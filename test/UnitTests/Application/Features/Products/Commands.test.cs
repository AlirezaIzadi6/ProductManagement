using AutoMapper;
using Moq;
using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.Create;
using Application.Interfaces;
using Application.Wrappers;
using UnitTests.Fixtures;
using Application.Features.Products.Update;

namespace UnitTests.Application.Features.Products;

[Collection("MyTests")]
public class ProductCommandsTest
{
    private readonly Mock<IProductRepositoryAsync> mockRepository;
    private readonly Mock<IMapper> mockMapper;
    private readonly ProductTestData testData;
    public ProductCommandsTest()
    {
        mockRepository = new Mock<IProductRepositoryAsync>();
        mockMapper = new Mock<IMapper>();
        testData = new ProductTestData();
    }

    public class CreateProductCommandTest : ProductCommandsTest
    {
        [Fact]
        public async Task WithCorrectData_CreateProduct()
        {
            var fakeProductWithId = testData.GetProduct1();
            var fakeProductWithoutId = testData.GetWithoutId(fakeProductWithId);
            var fakeProductDto = testData.GetDto(fakeProductWithId);
            var createProductCommand = testData.GetCreateCommand(fakeProductWithId);

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

        [Fact]
        public async Task WithFutureDate_ReturnError()
        {
            var command = testData.GetCreateCommand();
            command.ProduceDate = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            var handler = new CreateProductHandler(mockRepository.Object, mockMapper.Object);

            var result = await handler.Handle(command, new CancellationToken());

            Assert.False(result.Succeded);
            Assert.Null(result.Data);
            Assert.NotNull(result.Errors);
        }
    }

    public class UpdateProductCommandTest : ProductCommandsTest
    {
        [Fact]
        public async Task WithCorrectData_UpdateProduct()
        {
            var product = testData.GetProduct1();
            var productDto = testData.GetDto(product);
            var command = testData.GetUpdateCommand(product);

            mockRepository.Setup(rep => rep.GetByIdAsync(product.Id))
                .ReturnsAsync(product);
            mockRepository.Setup(rep => rep.IsUniqueAsync(product.Name, product.ProduceDate, product.Id))
                .ReturnsAsync(true);
            mockMapper.Setup(m => m.Map<Product>(command))
                .Returns(product);
            mockMapper.Setup(m => m.Map<ProductDto>(product))
                .Returns(productDto);

            var handler = new UpdateProductHandler(mockRepository.Object, mockMapper.Object);

            var response = await handler.Handle(command, new CancellationToken());

            Assert.True(response.Succeded);
            mockRepository.Verify(rep => rep.UpdateAsync(product), Times.Once);
            mockRepository.Verify(rep => rep.IsUniqueAsync(product.Name, product.ProduceDate, product.Id), Times.Once);
        }
    }
}
