using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface ITvShowsRepository
    {
        Task<ResponseMessage> GetTvShowByIdAsync(int tvShowId);
        Task<ResponseMessage> GetPopularTvShows();
        Task<ResponseMessage> GetTopRatedTvShows();
        Task<ResponseMessage> GetTrendingTvShows(string timeWindow);
    }
}