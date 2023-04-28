using AutoMapper;
using NetcoreCrudBaseApi.Domains.Dtos.Users;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Mappers;

public class UsersMapper : Profile
{
    public UsersMapper()
    {
        CreateMap<CreateUserDto, UserEntity>().ReverseMap();
        CreateMap<ReadUserDto, UserEntity>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
            .ReverseMap();        
        CreateMap<UpdateUserDto, UserEntity>().ReverseMap();
    }
}
