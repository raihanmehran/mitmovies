using Application.v1.DTOs;
using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.TvShows;

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

        public async Task<ResponseMessage> GetTvShowByIdAsync(int tvShowId)
        {
            var result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetTvShowAsync(id: tvShowId);

            return result;
        }
    }
}