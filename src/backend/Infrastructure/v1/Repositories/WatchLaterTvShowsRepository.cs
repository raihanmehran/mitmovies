using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class WatchLaterTvShowsRepository : IWatchLaterTvShowsRepository
    {
        private readonly DataContext _context;

        public WatchLaterTvShowsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> AddWatchLaterTvShowAsync(WatchLaterDto watchLaterDto, AppUser user)
        {
            if (watchLaterDto.TvShowId is 0 || user is null) return Response(
                statusCode: 404, message: "Data Not Provided");

            if (IsWatchLaterTvShowExist(tvShowId: watchLaterDto.TvShowId, user: user))
            {
                return Response(statusCode: 400, message: "Tv Show already exist in watch later");
            }

            var watchLaterTvShow = new WatchLater
            {
                TvShowId = watchLaterDto.TvShowId,
                AppUserId = user.Id
            };

            user.WatchLaters.Add(watchLaterTvShow);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Watch Later Tv Show Added");

            return Response(statusCode: 500,
                message: "Error While Adding Tv Show to Watch Later");
        }

        public async Task<ResponseMessage> RemoveWatchLaterTvShowAsync(int tvShowId, AppUser user)
        {
            if (tvShowId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (!IsWatchLaterTvShowExist(tvShowId: tvShowId, user: user)) return Response(
                statusCode: 403, message: "The Tv Show already removed");

            var watchLaterTvShow = GetWatchLaterTvShow(tvShowId: tvShowId, user: user);
            user.WatchLaters.Remove(watchLaterTvShow);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Tv Show Removed From Watch Laters");

            return Response(statusCode: 500,
                message: "Error While Removing Tv Show from Watch Laters");
        }

        private WatchLater GetWatchLaterTvShow(int tvShowId, AppUser user)
        {
            return user.WatchLaters.SingleOrDefault(x => x.TvShowId == tvShowId);
        }
        private bool IsWatchLaterTvShowExist(int tvShowId, AppUser user)
        {
            return (user.WatchLaters.Any(x =>
                x.TvShowId == tvShowId)) ? true : false;
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