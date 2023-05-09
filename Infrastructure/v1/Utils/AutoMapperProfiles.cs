using Application.v1.DTOs;
using AutoMapper;
using Domain.v1.Entities;

namespace Infrastructure.v1.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<RegisterUserDto, AppUser>();
            CreateMap<AppUser, MemberDto>();
            CreateMap<UserUpdateDto, AppUser>();
        }
    }
}