using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IFavouriteMoviesRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddMovieToFavourite(int movieId, AppUser user);
        Task<FavouriteMovie> GetFavouriteMovie(int movieId, int userId);
    }
}