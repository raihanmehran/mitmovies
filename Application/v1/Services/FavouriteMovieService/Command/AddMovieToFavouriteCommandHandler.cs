using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouriteMovieService.Command
{
    public class AddMovieToFavouriteCommandHandler : IRequestHandler<AddMovieToFavouriteCommand, ResponseMessage>
    {
        private readonly IFavouriteMoviesRepository _favouriteMoviesRepository;
        public AddMovieToFavouriteCommandHandler(IFavouriteMoviesRepository favouriteMoviesRepository)
        {
            _favouriteMoviesRepository = favouriteMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(AddMovieToFavouriteCommand request, CancellationToken cancellationToken)
        {
            return await _favouriteMoviesRepository.AddMovieToFavourite(
                movieId: request.MovieId, user: request.User);
        }
    }
}