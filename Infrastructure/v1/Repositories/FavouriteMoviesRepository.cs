using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Repositories
{
    public class FavouriteMoviesRepository : IFavouriteMoviesRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        public FavouriteMoviesRepository(DataContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public async Task<ResponseMessage> AddMovieToFavourite(int movieId, AppUser user)
        {
            if (movieId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (user.FavouriteMovies == null) user.FavouriteMovies = new List<FavouriteMovie>();
            else
            {
                var favMovie = await GetFavouriteMovie(movieId: movieId, userId: user.Id);

                if (favMovie != null) return Response(
                       statusCode: 401, message: "You already added this movie to favourites");
            }

            var favouriteMovie = new FavouriteMovie
            {
                AppUserId = user.Id,
                MovieId = movieId,
                User = user
            };

            user.FavouriteMovies.Add(favouriteMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Movie Added To Favourite");

            return Response(statusCode: 400, message: "Error While Adding Movie to Favourite");
        }

        public async Task<FavouriteMovie> GetFavouriteMovie(int movieId, int userId)
        {
            //return await _context.FavouriteMovies.Where(
            //    x => x.AppUserId == userId && x.MovieId == movieId).FirstOrDefaultAsync();
            return new FavouriteMovie();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        private ResponseMessage Response(int statusCode, string message, object data = null)
        {
            var response = new ResponseMessage();
            response.StatusCode = statusCode;
            response.Message = message;
            response.Data = data;

            return response;
        }
    }
}