using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Mappers
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User));
            CreateMap<PropertyDto, Property>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
