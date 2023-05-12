using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class WatchedMoviesRepository : IWatchedMoviesRepository
    {
        private readonly DataContext _context;
        public WatchedMoviesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> AddMovieToWatched(int movieId, AppUser user)
        {
            if (movieId <= 0 || user is null) return Response(
                statusCode: 400, message: "Data Not Provided");

            if (IsWatchedMovieExist(movieId: movieId, user: user)) return Response(
                statusCode: 401, message: "Movie Already Exist in Watched");

            var watchedMovie = new WatchedMovie
            {
                MovieId = movieId,
                AppUserId = user.Id
            };

            user.WatchedMovies.Add(watchedMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Movie Added To Watched");

            return Response(statusCode: 500,
                message: "Error while adding movie to watched");
        }

        public bool IsWatchedMovieExist(int movieId, AppUser user)
        {
            return user.WatchedMovies.Any(x => x.MovieId == movieId);
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