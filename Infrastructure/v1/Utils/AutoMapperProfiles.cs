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
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.Photos, opt => opt
                    .MapFrom(src => src.Photos))
                .ForMember(dest => dest.FavouriteMovies, opt => opt
                    .MapFrom(src => src.FavouriteMovies))
                .ForMember(dest => dest.FavouritePeople, opt => opt
                    .MapFrom(src => src.FavouritePeople));
            CreateMap<UserUpdateDto, AppUser>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<FavouriteMovie, FavouriteMovieDto>();
            CreateMap<FavouritePerson, FavouritePersonDto>();
            CreateMap<FavouriteTvShow, FavouriteTvShowDto>();
        }
    }
}