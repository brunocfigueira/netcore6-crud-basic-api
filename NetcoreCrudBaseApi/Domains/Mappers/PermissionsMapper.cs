using AutoMapper;
using NetcoreCrudBaseApi.Domains.Dtos.Permissions;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Mappers;

public class PermissionsMapper : Profile
{
    public PermissionsMapper()
    {
        CreateMap<CreatePermissionDto, PermissionEntity>().ReverseMap();
        CreateMap<ReadPermissionDto, PermissionEntity>()
            //.ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))                                
            .ReverseMap();
        CreateMap<UpdatePermissionDto, PermissionEntity>().ReverseMap();
    }
}
