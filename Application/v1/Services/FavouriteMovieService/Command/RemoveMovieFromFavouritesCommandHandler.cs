using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouriteMovieService.Command
{
    public class RemoveMovieFromFavouritesCommandHandler : IRequestHandler<RemoveMovieFromFavouritesCommand, ResponseMessage>
    {
        private readonly IFavouriteMoviesRepository _favouriteMoviesRepository;
        public RemoveMovieFromFavouritesCommandHandler(IFavouriteMoviesRepository favouriteMoviesRepository)
        {
            _favouriteMoviesRepository = favouriteMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(RemoveMovieFromFavouritesCommand request, CancellationToken cancellationToken)
        {
            return await _favouriteMoviesRepository.RemoveMovieFromFavourite(
                movieId: request.MovieId, user: request.User);
        }
    }
}