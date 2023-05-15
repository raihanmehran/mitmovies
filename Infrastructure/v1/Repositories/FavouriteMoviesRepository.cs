using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.Movies;

namespace Infrastructure.v1.Repositories
{
    public class FavouriteMoviesRepository : IFavouriteMoviesRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMoviesRepository _moviesRepository;
        public FavouriteMoviesRepository(DataContext context,
            IUserRepository userRepository, IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
            _userRepository = userRepository;
            _context = context;
        }
        public async Task<ResponseMessage> AddMovieToFavourite(int movieId, AppUser user)
        {
            if (movieId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (IsFavouriteMovieExist(movieId: movieId, user: user)) return Response(
                   statusCode: 401, message: "You already added this movie to favourites");

            var favouriteMovie = new FavouriteMovie
            {
                AppUserId = user.Id,
                MovieId = movieId
            };

            user.FavouriteMovies.Add(favouriteMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Movie Added To Favourites");

            return Response(statusCode: 400,
                message: "Error While Adding Movie to Favourites");
        }

        public bool IsFavouriteMovieExist(int movieId, AppUser user)
        {
            return (user.FavouriteMovies.Any(x =>
                x.MovieId == movieId)) ? true : false;
        }

        public async Task<ResponseMessage> RemoveMovieFromFavourite(int movieId, AppUser user)
        {
            if (movieId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (!IsFavouriteMovieExist(movieId: movieId, user: user)) return Response(
                statusCode: 403, message: "The movie already removed");

            var favouriteMovie = GetFavouriteMovie(movieId: movieId, user: user);
            user.FavouriteMovies.Remove(favouriteMovie);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Movie Removed From Favourites");

            return Response(statusCode: 500,
                message: "Error While Removing Movie to Favourites");
        }

        public FavouriteMovie GetFavouriteMovie(int movieId, AppUser user)
        {
            return user.FavouriteMovies.SingleOrDefault(x =>
                x.MovieId == movieId);
        }

        public async Task<ResponseMessage> GetFavouriteMoviesAsync(AppUser user)
        {
            if (user.FavouriteMovies.Count <= 0) return Response(
                statusCode: 404, message: "No Favourite Movies Found");

            var movies = new List<Movie>();

            foreach (var favouriteMovie in user.FavouriteMovies)
            {
                var result = await _moviesRepository.GetMovieById(
                    favouriteMovie.MovieId);
                    
                if (result.Data is not null) movies.Add(result.Data as Movie);
            }

            return Response(statusCode: 200, message: "Data Fetched Successfully",
                data: movies);
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