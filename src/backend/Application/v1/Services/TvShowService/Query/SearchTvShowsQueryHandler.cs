using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class SearchTvShowsQueryHandler : IRequestHandler<SearchTvShowsQuery, ResponseMessage>
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        public SearchTvShowsQueryHandler(ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(SearchTvShowsQuery request, CancellationToken cancellationToken)
        {
            return await _tvShowsRepository.SearchTvShowsAsync(query: request.Query);
        }
    }
}