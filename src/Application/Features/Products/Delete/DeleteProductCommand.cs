using MediatR;
using Application.Wrappers;

namespace Application.Features.Products.Delete;

public class DeleteProductCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string UserId { get; set; }
}
