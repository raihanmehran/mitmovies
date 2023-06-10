using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetTrendingTvShowsQueryHandler : IRequestHandler<GetTrendingTvShowsQuery, ResponseMessage>
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        public GetTrendingTvShowsQueryHandler(ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(GetTrendingTvShowsQuery request, CancellationToken cancellationToken)
        {
            return await _tvShowsRepository.GetTrendingTvShows(timeWindow: request.TimeWindow);
        }
    }
}