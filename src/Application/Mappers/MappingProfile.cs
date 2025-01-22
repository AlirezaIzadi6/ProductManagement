using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
