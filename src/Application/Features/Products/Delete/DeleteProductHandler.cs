using AutoMapper;
using MediatR;
using Application.Interfaces;
using Application.Wrappers;

namespace Application.Features.Products.Delete;

public class DeleteProductHandler : BaseProductCommandHandler, IRequestHandler<DeleteProductCommand, Response<int>>
{
    public DeleteProductHandler(IProductRepositoryAsync repository, IMapper mapper)
        : base(repository, mapper)
    {
    }

    public async Task<Response<int>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(command.Id);
        if (product == null) return new Response<int>("Product not found");

        if (command.UserId != product.CreatedByUserId) return new Response<int>("Not authorized");

        await _repository.DeleteAsync(product);
        return Response<int>.SuccessResponse;
    }
}
