using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class WatchedLaterRepository : IWatchLaterRepository
    {
        private readonly DataContext _context;

        public WatchedLaterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> AddWatchLaterMovieAsync(WatchLaterDto watchLaterDto, AppUser user)
        {
            if (watchLaterDto is null || user is null) return Response(
                statusCode: 404, message: "Data Not Provided");

            if (IsWatchLaterMovieExist(movieId: watchLaterDto.MovieId, user: user))
            {
                return Response(statusCode: 400, message: "Movie already exist in watch later");
            }

            var watchLaterMovie = new WatchLater
            {
                MovieId = watchLaterDto.MovieId,
                AppUserId = user.Id
            };

            user.WatchLaters.Add(watchLaterMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Watch Later Movie Added");

            return Response(statusCode: 500,
                message: "Error While Adding Movie to Watch Later");
        }

        public bool IsWatchLaterMovieExist(int movieId, AppUser user)
        {
            return (user.WatchLaters.Any(x =>
                x.MovieId == movieId)) ? true : false;
        }
        public bool IsWatchLaterTvShowExist(int tvShowId, AppUser user)
        {
            return (user.WatchLaters.Any(x =>
                x.TvShowId == tvShowId)) ? true : false;
        }

        public Task<ResponseMessage> AddWatchLaterTvShowAsync(WatchLaterDto watchLaterDto, AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> RemoveWatchLaterMovieAsync(int movieId, AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> RemoveWatchLaterTvShowAsync(int tvShowId, AppUser user)
        {
            throw new NotImplementedException();
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