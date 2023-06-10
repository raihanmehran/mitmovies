using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.TvShows;

namespace Infrastructure.v1.Repositories
{
    public class WatchedTvShowsRepository : IWatchedTvShowsRepository
    {
        private readonly DataContext _context;
        private readonly ITvShowsRepository _tvShowsRepository;
        public WatchedTvShowsRepository(DataContext context, ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
            _context = context;
        }

        public async Task<ResponseMessage> AddTvShowToWatched(int tvShowId, AppUser user)
        {
            if (tvShowId <= 0 || user is null) return Response(
                statusCode: 400, message: "Data Not Provided");

            if (IsWatchedTvShowExist(tvShowId: tvShowId, user: user)) return Response(
                statusCode: 401, message: "Movie Already Exist in Watched");

            user.WatchedTvShows
                .Add(GetTvShowToAdd(tvShowId: tvShowId, user: user));

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Tv Show Added Successfully To Watched");

            return Response(statusCode: 500,
                message: "Error while adding tv show to watched");
        }

        private WatchedTvShow GetTvShowToAdd(int tvShowId, AppUser user) =>
            new WatchedTvShow
            {
                TvShowId = tvShowId,
                AppUserId = user.Id
            };

        public bool IsWatchedTvShowExist(int tvShowId, AppUser user) =>
            user.WatchedTvShows.Any(x => x.TvShowId == tvShowId);

        public async Task<ResponseMessage> RemoveTvShowFromWatched(int tvShowId, AppUser user)
        {
            if (tvShowId <= 0 || user is null) return Response(
                statusCode: 400, message: "Data Not Provided");

            if (!IsWatchedTvShowExist(tvShowId: tvShowId, user: user)) return Response(
                statusCode: 401, message: "Tv Show Not Exist in Watched");

            user.WatchedTvShows.Remove(
                GetTvShowToRemove(tvShowId: tvShowId, user: user));

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Tv Show Remove From Watched");

            return Response(statusCode: 500,
                message: "Error while removing Tv Show from Watched");
        }

        public async Task<ResponseMessage> GetWatchedTvShowsAsync(AppUser user)
        {
            if (user.WatchedTvShows.Count <= 0) return Response(
                statusCode: 404, message: "No Watched Movies Found!");

            var tvShows = new List<TvShow>();

            foreach (var watchedTvShow in user.WatchedTvShows)
            {
                var result = await _tvShowsRepository.GetTvShowByIdAsync(
                    tvShowId: watchedTvShow.TvShowId);

                if (result.Data is not null) tvShows.Add(result.Data as TvShow);
            }

            return Response(statusCode: 200, message: "Data Fetched Successfully",
                data: tvShows);
        }

        private WatchedTvShow GetTvShowToRemove(int tvShowId, AppUser user) =>
            user.WatchedTvShows.FirstOrDefault(x =>
                x.TvShowId == tvShowId);

        public async Task<bool> SaveAllAsync() =>
            await _context.SaveChangesAsync() > 0;

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