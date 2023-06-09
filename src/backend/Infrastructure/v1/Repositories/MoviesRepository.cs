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
        public async Task<ResponseMessage> GetMovieByIdAsync(int movieId)
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMovieAsync(movieId: movieId);

            return result;
        }

        public async Task<ResponseMessage> GetMovieDetailByIdAsync(int movieId)
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMovieAsync(movieId: movieId, MovieMethods.Credits
                | MovieMethods.Videos
                | MovieMethods.Reviews
                | MovieMethods.Images
                | MovieMethods.Videos
                | MovieMethods.Keywords
                | MovieMethods.Lists
                | MovieMethods.WatchProviders
                | MovieMethods.Recommendations
                | MovieMethods.Changes
                | MovieMethods.ExternalIds
                | MovieMethods.Similar);

            return result;
        }

        public async Task<ResponseMessage> GetPopularMoviesAsync(int page = 1)
        {
            var result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMoviePopularListAsync(page: page);

            return result;
        }

        public async Task<ResponseMessage> GetTopRatedMoviesAsync(int page = 1)
        {
            var result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMovieTopRatedListAsync(page: page);

            return result;
        }

        public async Task<ResponseMessage> GetUpcomingMoviesAsync(int page = 1)
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetMovieUpcomingListAsync(page: page);

            return result;
        }

        public async Task<ResponseMessage> SearchMovieAsync(string payload)
        {
            ResponseMessage result = new ResponseMessage();

            var response = await _tmdbContext.client
                .SearchMovieAsync(query: payload, page: default, includeAdult: false);

            result.Data = response.Results;

            return result;
        }
    }
}