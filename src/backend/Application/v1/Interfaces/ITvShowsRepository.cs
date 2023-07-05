using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface ITvShowsRepository
    {
        Task<ResponseMessage> GetTvShowByIdAsync(int tvShowId);
        Task<ResponseMessage> GetPopularTvShows(int page = 1);
        Task<ResponseMessage> GetTopRatedTvShows(int page = 1);
        Task<ResponseMessage> GetTrendingTvShows(string timeWindow);
        Task<ResponseMessage> SearchTvShowsAsync(string query);
    }
}