using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.TvShows;

namespace Infrastructure.v1.Repositories
{
    public class FavouriteTvShowsRepository : IFavouriteTvShowsRepository
    {
        private readonly DataContext _context;
        private readonly ITvShowsRepository _tvShowsRepository;
        public FavouriteTvShowsRepository(DataContext context, ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
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

            return Response(statusCode: 500,
                message: "Error while adding tv show to favourtes");
        }

        public bool IsFavouriteTvShowExist(int tvShowId, AppUser user)
        {
            return (user.FavouriteTvShows.Any(x =>
                x.TvShowId == tvShowId)) ? true : false;
        }

        public async Task<ResponseMessage> RemoveTvShowToFavourites(int tvShowId, AppUser user)
        {
            if (tvShowId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (!IsFavouriteTvShowExist(tvShowId: tvShowId, user: user)) return Response(
                statusCode: 403, message: "The Tv Show already removed");

            var favouriteTvShow = GetFavouriteTvShow(tvShowId, user);
            user.FavouriteTvShows.Remove(favouriteTvShow);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Tv Show Removed From Favourites");

            return Response(statusCode: 500,
                message: "Error While Removing Tv Show From Favourites");
        }

        public async Task<ResponseMessage> GetFavouriteTvShowsAsync(AppUser user)
        {
            if (user.FavouriteTvShows.Count <= 0) return Response(
                statusCode: 404, message: "No Favourite Tv Shows Found");

            var tvShows = new List<TvShow>();

            foreach (var favouriteTvShow in user.FavouriteTvShows)
            {
                var result = await _tvShowsRepository
                    .GetTvShowByIdAsync(tvShowId: favouriteTvShow.TvShowId);

                if (result.Data is not null) tvShows.Add(result.Data as TvShow);
            }

            return Response(statusCode: 200, message: "Data Fetched Successfully",
                data: tvShows);
        }

        private FavouriteTvShow GetFavouriteTvShow(int tvShowId, AppUser user)
        {
            return user.FavouriteTvShows
                .SingleOrDefault(x => x.TvShowId == tvShowId);
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