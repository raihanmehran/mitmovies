using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchedTvShowService.Command
{
    public class AddTvShowToWatchedCommandHandler : IRequestHandler<AddTvShowToWatchedCommand, ResponseMessage>
    {
        private readonly IWatchedTvShowsRepository _watchedTvShowsRepository;
        public AddTvShowToWatchedCommandHandler(IWatchedTvShowsRepository watchedTvShowsRepository)
        {
            _watchedTvShowsRepository = watchedTvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(AddTvShowToWatchedCommand request, CancellationToken cancellationToken)
        {
            return await _watchedTvShowsRepository.AddTvShowToWatched(
                tvShowId: request.TvShowId, user: request.User);
        }
    }
}