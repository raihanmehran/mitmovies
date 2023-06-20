using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchLaterMovieService.Command
{
    public class RemoveWatchLaterMovieCommandHandler : IRequestHandler<RemoveWatchLaterMovieCommand, ResponseMessage>
    {
        private readonly IWatchLaterMoviesRepository _watchLaterMoviesRepository;

        public RemoveWatchLaterMovieCommandHandler(IWatchLaterMoviesRepository watchLaterMoviesRepository)
        {
            _watchLaterMoviesRepository = watchLaterMoviesRepository;
        }

        public async Task<ResponseMessage> Handle(RemoveWatchLaterMovieCommand request, CancellationToken cancellationToken)
        {
            return await _watchLaterMoviesRepository.RemoveWatchLaterMovieAsync(
                movieId: request.MovieId, user: request.User);
        }
    }
}