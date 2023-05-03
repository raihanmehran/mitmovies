using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetTopRatedTvShowsQueryHandler : IRequestHandler<GetTopRatedTvShowsQuery, ResponseMessage>
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        public GetTopRatedTvShowsQueryHandler(ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(GetTopRatedTvShowsQuery request, CancellationToken cancellationToken)
        {
            return await _tvShowsRepository.GetTopRatedTvShows();
        }
    }
}