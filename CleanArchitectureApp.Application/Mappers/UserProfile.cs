﻿using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Domain;

namespace CleanArchitectureApp.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserDto>()
                           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash.ToString()));
            CreateMap<UserDto, User>();
        }
    }
}
