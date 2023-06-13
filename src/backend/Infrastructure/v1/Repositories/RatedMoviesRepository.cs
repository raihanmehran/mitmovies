using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class RatedMoviesRepository : IRatedMoviesRepository
    {
        private readonly DataContext _context;
        public RatedMoviesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> AddMovieRatingAsync(RatedMovieDto ratedMovieDto, AppUser user)
        {
            if (ratedMovieDto is null || user is null) return Response(
                            statusCode: 404, message: "Data Not Provided");

            var newRatedMovie = new RatedMovie
            {
                MovieId = ratedMovieDto.MovieId,
                Rating = ratedMovieDto.Rating,
                AppUserId = user.Id
            };

            if (IsRatedMovieExist(movieId: ratedMovieDto.MovieId, user: user))
            {
                var ratedMovie = user.RatedMovies.SingleOrDefault(x =>
                    x.MovieId == newRatedMovie.MovieId);

                user.RatedMovies.Remove(ratedMovie);
            }

            user.RatedMovies.Add(newRatedMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Rated Movie Added");

            return Response(statusCode: 500,
                message: "Error While Adding Movie to Favourites");
        }

        public bool IsRatedMovieExist(int movieId, AppUser user)
        {
            return (user.RatedMovies.Any(x =>
                x.MovieId == movieId)) ? true : false;
        }

        public async Task<ResponseMessage> RemoveMovieRatingAsync(int movieId, AppUser user)
        {
            if (movieId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (!IsRatedMovieExist(movieId: movieId, user: user)) return Response(
                statusCode: 400, message: "The movie already removed");

            var ratedMovie = GetRatedMovie(movieId: movieId, user: user);
            user.RatedMovies.Remove(ratedMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Rated Movie Removed");

            return Response(statusCode: 500,
                message: "Error While Removing Rated Movie");

        }

        public RatedMovie GetRatedMovie(int movieId, AppUser user)
        {
            return user.RatedMovies.SingleOrDefault(x =>
                x.MovieId == movieId);
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