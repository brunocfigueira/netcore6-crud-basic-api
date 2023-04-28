using AutoMapper;
using NetcoreCrudBaseApi.Domains.Dtos.Profiles;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Mappers;

public class ProfilesMapper : Profile
{
    public ProfilesMapper()
    {
        CreateMap<CreateProfileDto, ProfileEntity>().ReverseMap();
        CreateMap<ReadProfileDto, ProfileEntity>()
            //.ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions))
            .ReverseMap();
        CreateMap<UpdateProfileDto, ProfileEntity>().ReverseMap();
    }
}
