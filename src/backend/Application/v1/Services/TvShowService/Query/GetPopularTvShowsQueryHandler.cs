using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetPopularTvShowsQueryHandler : IRequestHandler<GetPopularTvShowsQuery, ResponseMessage>
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        public GetPopularTvShowsQueryHandler(ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
        }

        public async Task<ResponseMessage> Handle(GetPopularTvShowsQuery request, CancellationToken cancellationToken)
        {
            return await _tvShowsRepository.GetPopularTvShows();
        }
    }
}