using AutoMapper;
using MediatR;
using Application.DTOs;
using Application.Wrappers;
using Application.Interfaces;

namespace Application.Features.Products.GetAll;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Response<IEnumerable<ProductDto>>>
{
    private readonly IProductRepositoryAsync _repository;
    private readonly IMapper _mapper;
    public GetAllProductsHandler(IProductRepositoryAsync repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var products = query.CreatedByUserId == null ?
            await _repository.ListAsync()
            : await _repository.GetProductsByCreatorAsync(query.CreatedByUserId);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return new Response<IEnumerable<ProductDto>>(productDtos);
    }
}
