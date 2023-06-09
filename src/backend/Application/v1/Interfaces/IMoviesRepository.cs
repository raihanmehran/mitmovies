using Application.v1.DTOs;
using TMDbLib.Objects.Movies;

namespace Application.v1.Interfaces
{
    public interface IMoviesRepository
    {
        Task<ResponseMessage> GetMovieByIdAsync(int movieId);
        Task<ResponseMessage> GetMovieDetailByIdAsync(int movieId);
        Task<ResponseMessage> SearchMovieAsync(string payload);
        Task<ResponseMessage> GetUpcomingMoviesAsync(int page);
        Task<ResponseMessage> GetPopularMoviesAsync(int page);
        Task<ResponseMessage> GetTopRatedMoviesAsync(int page);
    }
}