using AutoMapper;
using NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission;
using NetcoreCrudBaseApi.Domains.Entities;
using System.Collections.Generic;

namespace NetcoreCrudBaseApi.Domains.Mappers
{
    public class ProfilePermissionsMapper : Profile
    {
        public ProfilePermissionsMapper()
        {
            CreateMap<CreateProfilePermissionDto, ProfilePermissionEntity>().ReverseMap();
            CreateMap<ReadProfilePermissionDto, ProfilePermissionEntity>()                
                //.ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
                //.ForMember(dest => dest.Permission, opt => opt.MapFrom(src => src.Permission))
                .ReverseMap();            
            CreateMap<UpdateProfilePermissionDto, ProfilePermissionEntity>().ReverseMap();
        }
    }
}
