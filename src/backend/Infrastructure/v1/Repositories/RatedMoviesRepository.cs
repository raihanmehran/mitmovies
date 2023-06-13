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

            if (IsRatedMovieExist(movieId: ratedMovieDto.MovieId, user: user)) return Response(
                   statusCode: 400, message: "You already rated this movie");

            var ratedMovie = new RatedMovie
            {
                MovieId = ratedMovieDto.MovieId,
                Rating = ratedMovieDto.Rating,
                AppUserId = user.Id
            };

            user.RatedMovies.Add(ratedMovie);

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