using Application.v1.DTOs;
using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

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
                .GetMovieAsync(movieId: movieId, MovieMethods.Credits
                | MovieMethods.Videos
                | MovieMethods.Reviews
                | MovieMethods.WatchProviders
                | MovieMethods.Similar);

            return result;
        }

        public async Task<ResponseMessage> GetUpcomingMovies()
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMovieUpcomingListAsync();

            return result;
        }

        public async Task<ResponseMessage> SearchMovie(string payload)
        {
            ResponseMessage result = new ResponseMessage();

            SearchContainer<SearchMovie> response = _tmdbContext.client
                .SearchMovieAsync(query: payload, page: default, includeAdult: true).Result;

            result.Data = response.Results;

            return result;
        }
    }
}