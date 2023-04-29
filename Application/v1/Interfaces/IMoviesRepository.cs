using TMDbLib.Objects.Movies;

namespace Application.v1.Interfaces
{
    public interface IMoviesRepository
    {
        Task<Movie> GetMovie(int movieId);
    }
}