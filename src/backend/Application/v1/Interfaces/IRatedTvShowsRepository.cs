using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IRatedTvShowsRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddTvShowRatingAsync(
            RatedTvShowDto ratedTvShowDto, AppUser user);
        Task<ResponseMessage> RemoveTvShowRatingAsync(int tvShowId, AppUser user);
    }
}