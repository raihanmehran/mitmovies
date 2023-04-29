using Application.v1.DTOs;
using TMDbLib.Objects.Movies;

namespace Application.v1.Interfaces
{
    public interface IMoviesRepository
    {
        Task<ResponseMessage> GetMovieById(int movieId);
    }
}