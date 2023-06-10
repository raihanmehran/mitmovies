using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetTvShowByIdQueryHandler : IRequestHandler<GetTvShowByIdQuery, ResponseMessage>
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        public GetTvShowByIdQueryHandler(ITvShowsRepository tvShowsRepository)
        {
            _tvShowsRepository = tvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(GetTvShowByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tvShowsRepository.GetTvShowByIdAsync(
                tvShowId: request.TvShowId);
        }
    }
}