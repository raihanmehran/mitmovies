using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchLaterTvShowService.Command
{
    public class RemoveWatchLaterTvShowCommandHandler : IRequestHandler<RemoveWatchLaterTvShowCommand, ResponseMessage>
    {
        private readonly IWatchLaterTvShowsRepository _watchLaterTvShowsRepository;

        public RemoveWatchLaterTvShowCommandHandler(IWatchLaterTvShowsRepository watchLaterTvShowsRepository)
        {
            _watchLaterTvShowsRepository = watchLaterTvShowsRepository;
        }

        public async Task<ResponseMessage> Handle(RemoveWatchLaterTvShowCommand request, CancellationToken cancellationToken)
        {
            return await _watchLaterTvShowsRepository.RemoveWatchLaterTvShowAsync(
                tvShowId: request.TvShowId, user: request.User);
        }
    }
}