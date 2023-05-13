using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class WatchedTvShowsRepository : IWatchedTvShowsRepository
    {
        private readonly DataContext _context;
        public WatchedTvShowsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> AddTvShowToWatched(int tvShowId, AppUser user)
        {
            if (tvShowId <= 0 || user is null) return Response(
                statusCode: 400, message: "Data Not Provided");

            if (IsWatchedTvShowExist(tvShowId: tvShowId, user: user)) return Response(
                statusCode: 401, message: "Movie Already Exist in Watched");

            var WatchedTvShow = new WatchedTvShow
            {
                TvShowId = tvShowId,
                AppUserId = user.Id
            };

            user.WatchedTvShows.Add(WatchedTvShow);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Tv Show Added Successfully To Watched");

            return Response(statusCode: 500,
                message: "Error while adding tv show to watched");

        }

        public bool IsWatchedTvShowExist(int tvShowId, AppUser user)
        {
            return user.WatchedTvShows.Any(x => x.TvShowId == tvShowId);
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