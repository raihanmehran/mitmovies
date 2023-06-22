using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.RatedTvShowService.Command
{
    public class RemoveTvShowRatingCommandHandler : IRequestHandler<RemoveTvShowRatingCommand, ResponseMessage>
    {
        private readonly IRatedTvShowsRepository _ratedTvShowsRepository;

        public RemoveTvShowRatingCommandHandler(IRatedTvShowsRepository ratedTvShowsRepository)
        {
            _ratedTvShowsRepository = ratedTvShowsRepository;
        }

        public async Task<ResponseMessage> Handle(RemoveTvShowRatingCommand request, CancellationToken cancellationToken)
        {
            return await _ratedTvShowsRepository.RemoveTvShowRatingAsync(
                tvShowId: request.TvShowId, user: request.User);
        }
    }
}