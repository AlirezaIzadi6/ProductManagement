using MediatR;
using Application.DTOs;
using Application.Wrappers;

namespace Application.Features.Products.get;

public class GetProductByIdQuery(int id)
    : IRequest<Response<ProductDto>>
{
    public int Id { get; private set; } = id;
}
