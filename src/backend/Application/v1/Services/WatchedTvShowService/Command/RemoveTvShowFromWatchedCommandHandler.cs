using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchedTvShowService.Command
{
    public class RemoveTvShowFromWatchedCommandHandler : IRequestHandler<RemoveTvShowFromWatchedCommand, ResponseMessage>
    {
        private readonly IWatchedTvShowsRepository _watchedTvShowsRepository;
        public RemoveTvShowFromWatchedCommandHandler(IWatchedTvShowsRepository watchedTvShowsRepository)
        {
            _watchedTvShowsRepository = watchedTvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(RemoveTvShowFromWatchedCommand request, CancellationToken cancellationToken)
        {
            return await _watchedTvShowsRepository.RemoveTvShowFromWatched(
                tvShowId: request.TvShowId, user: request.User);
        }
    }
}