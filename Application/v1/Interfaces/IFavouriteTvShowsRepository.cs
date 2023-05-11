using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IFavouriteTvShowsRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddTvShowToFavourites(int tvShowId, AppUser user);
        Task<ResponseMessage> RemoveTvShowToFavourites(int tvShowId, AppUser user);
        bool IsFavouriteTvShowExist(int tvShowId, AppUser user);
    }
}