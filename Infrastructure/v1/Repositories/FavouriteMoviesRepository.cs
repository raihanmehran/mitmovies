using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

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

            if (user.FavouriteMovies.Any(x => x.MovieId == movieId)) return Response(
                statusCode: 401, message: "You already added this movie to favourites");

            var favouriteMovie = new FavouriteMovie
            {
                AppUserId = user.Id,
                MovieId = movieId,
                Date = DateTime.UtcNow
            };

            user.FavouriteMovies.Add(favouriteMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Movie Added To Favourite");

            return Response(statusCode: 400, message: "Error While Adding Movie to Favourite");
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