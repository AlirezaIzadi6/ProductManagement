using MediatR;
using Application.DTOs;
using Application.Wrappers;

namespace Application.Features.Products.Update;

public class UpdateProductCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string RequestUserId { get; set; }
    public string Name { get; set; }
    public DateOnly ProduceDate { get; set; }
    public string ManufactureEmail { get; set; }
    public string ManufacturePhone { get; set; }
    public bool IsAvailable { get; set; }
}
