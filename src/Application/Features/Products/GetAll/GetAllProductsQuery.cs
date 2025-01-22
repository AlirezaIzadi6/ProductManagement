using MediatR;
using Application.DTOs;
using Application.Wrappers;

namespace Application.Features.Products.GetAll;

public class GetAllProductsQuery : IRequest<Response<IEnumerable<ProductDto>>>
{
    public string? CreatedByUserId { get; set; }
}
