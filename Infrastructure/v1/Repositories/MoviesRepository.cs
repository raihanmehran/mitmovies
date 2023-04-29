using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.Movies;

namespace Infrastructure.v1.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly TmdbContext _tmdbContext;
        public MoviesRepository(TmdbContext tmdbContext)
        {
            _tmdbContext = tmdbContext;
        }
        public async Task<Movie> GetMovie(int movieId)
        {
            Movie movie = await _tmdbContext.client
                .GetMovieAsync(movieId: movieId);

            return movie;
        }
    }
}