using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IWatchedMoviesRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddMovieToWatched(int movieId, AppUser user);
        bool IsWatchedMovieExist(int movieId, AppUser user);
    }
}