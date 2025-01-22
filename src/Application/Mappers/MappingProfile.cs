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

        CreateMap<ValidationFailure, string>()
            .ForMember(desc => desc, opt => opt.MapFrom(src => src.ErrorMessage));
    }
}
