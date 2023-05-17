using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchedTvShowService.Query
{
    public class GetWatchedTvShowsQueryHandler : IRequestHandler<GetWatchedTvShowsQuery, ResponseMessage>
    {
        private readonly IWatchedTvShowsRepository _watchedTvShowsRepository;
        public GetWatchedTvShowsQueryHandler(IWatchedTvShowsRepository watchedTvShowsRepository)
        {
            _watchedTvShowsRepository = watchedTvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(GetWatchedTvShowsQuery request, CancellationToken cancellationToken)
        {
            return await _watchedTvShowsRepository.GetWatchedTvShowsAsync(
                user: request.User);
        }
    }
}