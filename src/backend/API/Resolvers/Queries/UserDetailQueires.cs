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
using System.Reflection.Metadata.Ecma335;

namespace API.Resolvers.Queries
{
    public class UserDetailQueires
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly ITvShowsRepository _tvShowsRepository;
        public UserDetailQueires(IMoviesRepository moviesRepository, ITvShowsRepository tvShowsRepository)
        {
            _moviesRepository = moviesRepository;
            _tvShowsRepository = tvShowsRepository;
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
        // TV SHOWS
        [Authorize(Policy = "RequireAuthenticated")]
        public async ValueTask<List<TvShowDto>> GetFavoriteTvShows(
            [Service] DataContext context,
            [Service] IHttpContextAccessor httpContextAccessor
        )
        {
            try
            {
                var tvShows = new List<TvShowDto>();
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

                foreach (var favoriteTvShow in user.FavouriteTvShows)
                {
                    var result = await _tvShowsRepository
                        .GetTvShowByIdAsync(tvShowId: favoriteTvShow.TvShowId);

                    if (result.Data is not null)
                    {
                        var retrievedTvShow = result.Data as TvShow;

                        var tvShow = new TvShowDto
                        {
                            Id = retrievedTvShow.Id,
                            FirstAirDate = retrievedTvShow.FirstAirDate,
                            InProduction = retrievedTvShow.InProduction,
                            LastAirDate = retrievedTvShow.LastAirDate,
                            Name = retrievedTvShow.Name,
                            NumberOfEpisodes = retrievedTvShow.NumberOfEpisodes,
                            NumberOfSeasons = retrievedTvShow.NumberOfSeasons,
                            Overview = retrievedTvShow.Overview,
                            Popularity = retrievedTvShow.Popularity,
                            PosterPath = retrievedTvShow.PosterPath,
                            OriginalLanguage = retrievedTvShow.OriginalLanguage,
                            OriginalName = retrievedTvShow.Name

                        };

                        tvShows.Add(tvShow);
                    }
                }
                
                return tvShows;
            }
            catch (Exception) { throw; }

        }
        public string Hello()
        {
            return "Hello";
        }
    }
}