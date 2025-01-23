using AutoMapper;
using Application.Features.Products.Create;
using Application.Features.Products.Update;
using Web.DTOs;

namespace Web.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductDto, CreateProductCommand>();
        CreateMap<UpdateProductDto, UpdateProductCommand>();
    }
}
