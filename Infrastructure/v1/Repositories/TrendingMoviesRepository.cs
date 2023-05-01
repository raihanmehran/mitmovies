using Application.v1.DTOs;
using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class TrendingMoviesRepository : ITrendingMoviesRepository
    {
        private readonly TmdbContext _tmdbContext;
        public TrendingMoviesRepository(TmdbContext tmdbContext)
        {
            _tmdbContext = tmdbContext;
        }
        public async Task<ResponseMessage> GetTodayTrendingMovies()
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client.GetTrendingMoviesAsync(timeWindow:
                    TMDbLib.Objects.Trending.TimeWindow.Day);

            return result;
        }
    }
}