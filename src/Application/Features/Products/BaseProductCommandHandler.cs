using AutoMapper;
using Application.Interfaces;

namespace Application.Features.Products;

public class BaseProductCommandHandler
{
    protected readonly IProductRepositoryAsync _repository;
    protected readonly IMapper _mapper;
    public BaseProductCommandHandler(IProductRepositoryAsync repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}
