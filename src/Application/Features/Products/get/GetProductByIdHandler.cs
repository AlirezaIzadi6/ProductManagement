using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;

namespace Application.Features.Products.get;

public class GetProductByIdHandler : BaseProductQueryHandler, IRequestHandler<GetProductByIdQuery, Response<ProductDto>>
{
    public GetProductByIdHandler(IProductRepositoryAsync repository, IMapper mapper)
        : base(repository, mapper)
    {
    }

    public async Task<Response<ProductDto>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(query.Id);
        if (product == null) return new Response<ProductDto>("Product not found");

        var productDto = _mapper.Map<ProductDto>(product);
        return new Response<ProductDto>(productDto);
    }
}
