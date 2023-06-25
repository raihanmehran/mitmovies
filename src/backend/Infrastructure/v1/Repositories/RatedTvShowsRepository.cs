using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class RatedTvShowsRepository : IRatedTvShowsRepository
    {
        private readonly DataContext _context;

        public RatedTvShowsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> AddTvShowRatingAsync(RatedTvShowDto ratedTvShowDto, AppUser user)
        {
            if (ratedTvShowDto.TvShowId is 0 || user is null) return Response(
                statusCode: 404, message: "Data Not Provided");

            var newRatedTvShow = new RatedTvShow
            {
                TvShowId = ratedTvShowDto.TvShowId,
                Rating = ratedTvShowDto.Rating,
                AppUserId = user.Id
            };

            if (IsRatedTvShowExist(tvShowId: ratedTvShowDto.TvShowId, user: user))
            {
                var ratedTvShow = user.RatedTvShows.SingleOrDefault(x =>
                    x.TvShowId == ratedTvShowDto.TvShowId);

                user.RatedTvShows.Remove(ratedTvShow);
            }

            user.RatedTvShows.Add(newRatedTvShow);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Rated TvShow Added");

            return Response(statusCode: 500,
                message: "Error While Adding TvShow to Favourites");
        }

        public async Task<ResponseMessage> RemoveTvShowRatingAsync(int tvShowId, AppUser user)
        {
            if (tvShowId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (!IsRatedTvShowExist(tvShowId: tvShowId, user: user)) return Response(
                statusCode: 400, message: "The TvShow already removed");

            var ratedTvShow = GetRatedTvShow(tvShowId: tvShowId, user: user);
            user.RatedTvShows.Remove(ratedTvShow);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Rated TvShow Removed");

            return Response(statusCode: 500,
                message: "Error While Removing Rated TvShow");
        }

        private RatedTvShow GetRatedTvShow(int tvShowId, AppUser user)
        {
            return user.RatedTvShows.SingleOrDefault(x =>
                x.TvShowId == tvShowId);
        }
        public bool IsRatedTvShowExist(int tvShowId, AppUser user)
        {
            return (user.RatedTvShows.Any(x =>
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