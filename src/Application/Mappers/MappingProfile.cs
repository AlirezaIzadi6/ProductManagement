using AutoMapper;
using FluentValidation.Results;
using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.Create;

namespace Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductCommand, Product>();
    }
}
