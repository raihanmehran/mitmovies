using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.RatedTvShowService.Command
{
    public class AddTvShowRatingCommandHandler : IRequestHandler<AddTvShowRatingCommand, ResponseMessage>
    {
        private readonly IRatedTvShowsRepository _ratedTvShowsRepository;

        public AddTvShowRatingCommandHandler(IRatedTvShowsRepository ratedTvShowsRepository)
        {
            _ratedTvShowsRepository = ratedTvShowsRepository;
        }

        async Task<ResponseMessage> IRequestHandler<AddTvShowRatingCommand, ResponseMessage>.Handle(AddTvShowRatingCommand request, CancellationToken cancellationToken)
        {
            return await _ratedTvShowsRepository.AddTvShowRatingAsync(
                ratedTvShowDto: request.RatedTvShowDto, user: request.User);
        }
    }
}