using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IWatchLaterMoviesRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddWatchLaterMovieAsync(
            WatchLaterDto watchLaterDto, AppUser user);
        Task<ResponseMessage> RemoveWatchLaterMovieAsync(
            int movieId, AppUser user);
    }
}