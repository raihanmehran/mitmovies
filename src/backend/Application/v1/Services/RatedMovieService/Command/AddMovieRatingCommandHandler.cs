using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.RatedMovieService.Command
{
    public class AddMovieRatingCommandHandler : IRequestHandler<AddMovieRatingCommand, ResponseMessage>
    {
        private readonly IRatedMoviesRepository _ratedMoviesRepository;
        public AddMovieRatingCommandHandler(IRatedMoviesRepository ratedMoviesRepository)
        {
            _ratedMoviesRepository = ratedMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(AddMovieRatingCommand request, CancellationToken cancellationToken)
        {
            return await _ratedMoviesRepository.AddMovieRatingAsync(
                ratedMovieDto: request.RatedMovieDto, user: request.User);
        }
    }
}