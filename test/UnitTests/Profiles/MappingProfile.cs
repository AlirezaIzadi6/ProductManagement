﻿using AutoMapper;
using Domain.Entities;
using Application.DTOs;
using Application.Features.Products.Create;
using Application.Features.Products.Update;

namespace UnitTests.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CreateProductCommand, Product>().ReverseMap(      );
        CreateMap<UpdateProductCommand, Product>()
            .ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.RequestUserId))
            .ReverseMap();
    }
}
