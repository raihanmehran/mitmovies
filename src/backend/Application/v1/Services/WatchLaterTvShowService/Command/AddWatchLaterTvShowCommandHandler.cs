using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchLaterTvShowService.Command
{
    public class AddWatchLaterTvShowCommandHandler : IRequestHandler<AddWatchLaterTvShowCommand, ResponseMessage>
    {
        private readonly IWatchLaterTvShowsRepository _watchLaterTvShowsRepository;

        public AddWatchLaterTvShowCommandHandler(IWatchLaterTvShowsRepository watchLaterTvShowsRepository)
        {
            _watchLaterTvShowsRepository = watchLaterTvShowsRepository;
        }

        public async Task<ResponseMessage> Handle(AddWatchLaterTvShowCommand request, CancellationToken cancellationToken)
        {
            return await _watchLaterTvShowsRepository.AddWatchLaterTvShowAsync(
                watchLaterDto: request.WatchLaterDto, user: request.User);
        }
    }
}