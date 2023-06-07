using Application.v1.DTOs;
using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.TvShows;
using TMDbLib.Objects.Trending;

namespace Infrastructure.v1.Repositories
{
    public class TvShowsRepository : ITvShowsRepository
    {
        private readonly TmdbContext _tmdbContext;
        public TvShowsRepository(TmdbContext tmdbContext)
        {
            _tmdbContext = tmdbContext;
        }
        public async Task<ResponseMessage> GetPopularTvShows()
        {
            var result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetTvShowListAsync(TvShowListType.Popular);

            return result;
        }

        public async Task<ResponseMessage> GetTopRatedTvShows()
        {
            var result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetTvShowListAsync(TvShowListType.TopRated);

            return result;
        }

        public async Task<ResponseMessage> GetTrendingTvShows(string timeWindow)
        {
            var tvshows = await _tmdbContext.client
                .GetTrendingTvAsync(timeWindow:
                    timeWindow == "today" ? TimeWindow.Day : TimeWindow.Week);

            return tvshows.Results.Count > 0
                ? Response(statusCode: 200, message: "Success", data: tvshows.Results)
                : Response(statusCode: 404, message: "Not Found");
        }

        public async Task<ResponseMessage> GetTvShowByIdAsync(int tvShowId)
        {
            var result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetTvShowAsync(id: tvShowId);

            return result;
        }

        private ResponseMessage Response(int statusCode, string message, object data = null)
        {
            var response = new ResponseMessage();
            response.StatusCode = statusCode;
            response.Message = message;
            response.Data = data;

            return response;
        }
    }
}