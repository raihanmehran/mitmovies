using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IRatedMoviesRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddMovieRatingAsync(
            RatedMovieDto ratedMovieDto, AppUser user);
    }
}