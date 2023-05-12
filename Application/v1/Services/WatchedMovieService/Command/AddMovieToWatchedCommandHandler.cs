using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchedMovieService.Command
{
    public class AddMovieToWatchedCommandHandler : IRequestHandler<AddMovieToWatchedCommand, ResponseMessage>
    {
        private readonly IWatchedMoviesRepository _watchedMovieRepository;
        public AddMovieToWatchedCommandHandler(IWatchedMoviesRepository watchedMovieRepository)
        {
            _watchedMovieRepository = watchedMovieRepository;
        }
        public async Task<ResponseMessage> Handle(AddMovieToWatchedCommand request, CancellationToken cancellationToken)
        {
            return await _watchedMovieRepository.AddMovieToWatched(
                movieId: request.MovieId, user: request.User);
        }
    }
}