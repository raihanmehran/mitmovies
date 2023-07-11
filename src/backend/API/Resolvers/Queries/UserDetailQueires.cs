using Infrastructure.v1.Contexts;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TMDbLib.Objects.Movies;
using Application.v1.Interfaces;
using API.Extensions;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace API.Resolvers.Queries
{
    public class UserDetailQueires
    {
        private readonly IMoviesRepository _moviesRepository;
        public UserDetailQueires(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        // TO BE CONFIGURED!!!!
        // [UseProjection]
        // [UseFiltering]
        // [UseSorting]
        [Authorize(Policy = "RequireAuthenticated")]
        public async ValueTask<List<Movie>> GetFavoriteMovies(
            [Service] DataContext context,
            [Service] IHttpContextAccessor httpContextAccessor
            )
        {
            try
            {
                var movies = new List<Movie>();
                var userId = httpContextAccessor.HttpContext.User.GetUserId();

                if (userId <= 0) return movies;

                var user = await context.Users
                    .Where(x => x.Id == userId)
                    .Select(x => new
                    {
                        UserId = x.Id,
                        FavoriteMovies = x.FavouriteMovies
                    })
                    .SingleOrDefaultAsync();

                if (user.FavoriteMovies.Count == 0) return movies;

                foreach (var movie in user.FavoriteMovies)
                {

                    var result = await _moviesRepository.GetMovieByIdAsync(
                        movieId: movie.MovieId);

                    if (result.Data is not null) movies.Add(result.Data as Movie);
                }

                return movies;
            }
            catch (Exception) { throw; }
        }

        public string Hello()
        {
            return "Hello";
        }
    }
}