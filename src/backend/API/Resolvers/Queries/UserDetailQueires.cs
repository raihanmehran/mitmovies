using Infrastructure.v1.Contexts;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TMDbLib.Objects.Movies;
using Application.v1.Interfaces;
using API.Extensions;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using TMDbLib.Objects.TvShows;
using Application.v1.DTOs;

namespace API.Resolvers.Queries
{
    public class UserDetailQueires
    {
        private readonly IMoviesRepository _moviesRepository;
        public UserDetailQueires(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        // MOVIES

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
                    }).AsNoTracking()
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

        [Authorize(Policy = "RequireAuthenticated")]
        public async ValueTask<List<Movie>> GetWatchedMovies(
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
                        userId = x.Id,
                        x.WatchedMovies
                    })
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

                if (user.WatchedMovies.Count == 0) return movies;

                foreach (var movie in user.WatchedMovies)
                {
                    var result = await _moviesRepository.GetMovieByIdAsync(
                        movieId: movie.MovieId);

                    if (result.Data is not null) movies.Add(result.Data as Movie);
                }

                return movies;
            }
            catch (Exception) { throw; }
        }

        [Authorize(Policy = "RequireAuthenticated")]
        public async ValueTask<List<Movie>> GetWatchLaterMovies(
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
                        userId = x.Id,
                        watchLaterMovies = x.WatchLaters.Where(x => x.MovieId != 0).ToList()
                    })
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

                if (user.watchLaterMovies.Count == 0) return movies;

                foreach (var movie in user.watchLaterMovies)
                {
                    var result = await _moviesRepository
                        .GetMovieByIdAsync(movieId: movie.MovieId);

                    if (result.Data is not null) movies.Add(result.Data as Movie);
                }

                // Using Multi threadding
                // var tasks = user.watchLaterMovies.Select(async movie =>
                // {
                //     var result = await _moviesRepository.GetMovieByIdAsync(movieId: movie.MovieId);
                //     return result.Data as Movie;
                // });

                // var movieResults = await Task.WhenAll(tasks);
                // movies.AddRange(movieResults.Where(movie => movie is not null));


                return movies;
            }
            catch (Exception) { throw; }
        }

        [Authorize(Policy = "RequireAuthenticated")]
        public async ValueTask<List<RatedMovieDetailDto>> GetRatedMovies(
            [Service] DataContext context,
            [Service] IHttpContextAccessor httpContextAccessor
        )
        {
            var movies = new List<RatedMovieDetailDto>();
            var userId = httpContextAccessor.HttpContext.User.GetUserId();

            if (userId <= 0) return movies;

            var user = await context.Users
                .Where(x => x.Id == userId)
                .Select(x => new
                {
                    userId = x.Id,
                    x.RatedMovies
                })
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (user.RatedMovies.Count == 0) return movies;

            foreach (var movie in user.RatedMovies)
            {
                var result = await _moviesRepository
                    .GetMovieByIdAsync(movieId: movie.MovieId);

                if (result.Data is not null)
                {
                    var movieWithRating = new RatedMovieDetailDto
                    {
                        Rating = movie.Rating,
                        Movie = result.Data as Movie
                    };

                    movies.Add(movieWithRating);
                }
            }

            return movies;
        }

        public string Hello()
        {
            return "Hello";
        }
    }
}