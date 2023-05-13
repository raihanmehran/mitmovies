using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IWatchedTvShowsRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddTvShowToWatched(int tvShowId, AppUser user);
        bool IsWatchedTvShowExist(int tvShowId, AppUser user);
    }
}