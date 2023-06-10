using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface ITrendingMoviesRepository
    {
        Task<ResponseMessage> GetTodayTrendingMovies();
        Task<ResponseMessage> GetThisWeekTrendingMovies();
    }
}