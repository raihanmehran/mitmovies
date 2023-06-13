using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.RatedMovieService.Command
{
    public class RemoveMovieRatingCommandHandler : IRequestHandler<RemoveMovieRatingCommand, ResponseMessage>
    {
        private readonly IRatedMoviesRepository _ratedMoviesRepository;
        public RemoveMovieRatingCommandHandler(IRatedMoviesRepository ratedMoviesRepository)
        {
            _ratedMoviesRepository = ratedMoviesRepository;
        }

        public async Task<ResponseMessage> Handle(RemoveMovieRatingCommand request, CancellationToken cancellationToken)
        {
            return await _ratedMoviesRepository.RemoveMovieRatingAsync(
                movieId: request.MovieId, user: request.User);
        }
    }
}