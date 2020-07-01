using AutoMapper;
using Keezag.HHSurge.Application.Model;
using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keezag.HHSurge.Application.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Profiles.FirstOrDefault().Document))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Profiles.FirstOrDefault().Address))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Profiles.FirstOrDefault().Avatar))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Profiles.FirstOrDefault().Type.ToString()));

        }
    }
}