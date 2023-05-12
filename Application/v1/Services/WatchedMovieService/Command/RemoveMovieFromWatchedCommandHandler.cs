using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchedMovieService.Command
{
    public class RemoveMovieFromWatchedCommandHandler : IRequestHandler<RemoveMovieFromWatchedCommand, ResponseMessage>
    {
        private readonly IWatchedMoviesRepository _watchedMoviesRepository;
        public RemoveMovieFromWatchedCommandHandler(IWatchedMoviesRepository watchedMoviesRepository)
        {
            _watchedMoviesRepository = watchedMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(RemoveMovieFromWatchedCommand request, CancellationToken cancellationToken)
        {
            return await _watchedMoviesRepository.RemoveMovieFromWatched(
                movieId: request.MovieId, user: request.User);
        }
    }
}