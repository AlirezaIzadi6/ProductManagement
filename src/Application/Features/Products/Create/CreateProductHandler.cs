using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;
using Application.Wrappers;

namespace Application.Features.Products.Create;

public class CreateProductHandler : BaseProductCommandHandler, IRequestHandler<CreateProductCommand, Response<ProductDto>>
{
    public CreateProductHandler(IProductRepositoryAsync repository, IMapper mapper)
        : base(repository, mapper)
    {
    }

    public async Task<Response<ProductDto>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator(_repository);
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            var response = Response<ProductDto>.FailiorResponse;
            response.Errors = ValidationFailureToString.GetList(validationResult.Errors);
            return response;
        }

        var productToBeCreated = _mapper.Map<Product>(command);
        var createdProduct = await _repository.CreateAsync(productToBeCreated);
        var productDto = _mapper.Map<ProductDto>(createdProduct);
        return new Response<ProductDto>(productDto);
    }
}