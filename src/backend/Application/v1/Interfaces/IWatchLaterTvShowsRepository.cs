using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IWatchLaterTvShowsRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddWatchLaterTvShowAsync(
            WatchLaterDto watchLaterDto, AppUser user);
        Task<ResponseMessage> RemoveWatchLaterTvShowAsync(
            int tvShowId, AppUser user);
    }
}