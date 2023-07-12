using API.Extensions;
using Application.v1.Interfaces;
using HotChocolate.Authorization;
using Infrastructure.v1.Contexts;
using Microsoft.EntityFrameworkCore;
using TMDbLib.Objects.TvShows;

namespace API.Resolvers.Queries
{
    public class TvShowsQueries
    {
        private readonly ITvShowsRepository _tvShowsRepository;

        public TvShowsQueries(ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
        }

        [Authorize(Policy = "RequireAuthenticated")]
        public async ValueTask<List<TvShow>> GetFavoriteTvShows(
            [Service] DataContext context,
            [Service] IHttpContextAccessor httpContextAccessor
        )
        {
            try
            {
                var tvShows = new List<TvShow>();
                var userId = httpContextAccessor.HttpContext.User.GetUserId();

                if (userId <= 0) return tvShows;

                var user = await context.Users
                    .Where(x => x.Id == userId)
                    .Select(x => new
                    {
                        userId = x.Id,
                        x.FavouriteTvShows
                    })
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

                if (user.FavouriteTvShows.Count <= 0) return tvShows;

                foreach (var tvShow in user.FavouriteTvShows)
                {
                    var result = await _tvShowsRepository
                        .GetTvShowByIdAsync(tvShowId: tvShow.TvShowId);

                    if (result.Data is not null) tvShows.Add(result.Data as TvShow);
                }

                return tvShows;
            }
            catch (Exception) { throw; }
        }
    }
}