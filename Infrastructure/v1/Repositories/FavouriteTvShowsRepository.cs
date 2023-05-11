using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class FavouriteTvShowsRepository : IFavouriteTvShowsRepository
    {
        private readonly DataContext _context;
        public FavouriteTvShowsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> AddTvShowToFavourites(int tvShowId, AppUser user)
        {
            if (tvShowId <= 0 || user is null) return Response(
                statusCode: 400, message: "Data Not Provided");

            if (IsFavouriteTvShowExist(tvShowId: tvShowId, user: user)) return Response(
                statusCode: 400, message: "You already added this Tv Show to favourites");

            var favouriteTvShow = new FavouriteTvShow
            {
                TvShowId = tvShowId,
                AppUserId = user.Id
            };

            user.FavouriteTvShows.Add(favouriteTvShow);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Tv Show Added To Favourites");

            return Response(statusCode: 500, message: "Error while adding tv show to favourtes");
        }

        public bool IsFavouriteTvShowExist(int tvShowId, AppUser user)
        {
            return (user.FavouriteTvShows.Any(x =>
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