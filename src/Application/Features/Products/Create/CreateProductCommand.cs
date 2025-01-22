using MediatR;
using Application.DTOs;
using Application.Wrappers;

namespace Application.Features.Products.Create;

public class CreateProductCommand : IRequest<Response<ProductDto>>
{
    public string CreatedByUserId { get; set; }
    public string Name { get; set; }
    public DateOnly ProduceDate { get; set; }
    public string ManufactureEmail { get; set; }
    public string ManufacturePhone { get; set; }
    public bool IsAvailable { get; set; }
}