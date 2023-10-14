using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Domain;

namespace CleanArchitectureApp.Application.Mappers
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Temporary, opt => opt.MapFrom(src => src.Temporary==1));
            CreateMap<PropertyDto, Property>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Temporary, opt => opt.MapFrom(src => src.Temporary?1:0));
        }
    }
}
