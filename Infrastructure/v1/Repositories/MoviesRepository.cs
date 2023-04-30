using Application.v1.DTOs;
using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Trending;

namespace Infrastructure.v1.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly TmdbContext _tmdbContext;
        public MoviesRepository(TmdbContext tmdbContext)
        {
            _tmdbContext = tmdbContext;
        }
        public async Task<ResponseMessage> GetMovieById(int movieId)
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMovieAsync(movieId: movieId);

            return result;
        }

        public async Task<ResponseMessage> GetMovieDetailById(int movieId)
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMovieAsync(movieId: movieId, MovieMethods.Credits | MovieMethods.Videos | MovieMethods.Reviews | MovieMethods.WatchProviders);

            return result;
        }
    }
}