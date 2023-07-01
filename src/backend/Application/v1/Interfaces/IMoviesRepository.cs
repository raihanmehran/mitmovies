using Application.v1.DTOs;
using TMDbLib.Objects.Movies;

namespace Application.v1.Interfaces
{
    public interface IMoviesRepository
    {
        Task<ResponseMessage> GetMovieByIdAsync(int movieId);
        Task<ResponseMessage> GetMovieDetailByIdAsync(int movieId);
        Task<ResponseMessage> SearchMovieAsync(string payload);
        Task<ResponseMessage> GetUpcomingMoviesAsync(int page = 0);
        Task<ResponseMessage> GetPopularMoviesAsync();
        Task<ResponseMessage> GetTopRatedMoviesAsync();
    }
}