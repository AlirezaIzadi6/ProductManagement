using AutoMapper;
using Application.Interfaces;

namespace Application.Features.Products;

public class BaseProductQueryHandler
{
    protected readonly IProductRepositoryAsync _repository;
    protected readonly IMapper _mapper;
    public BaseProductQueryHandler(IProductRepositoryAsync repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}
