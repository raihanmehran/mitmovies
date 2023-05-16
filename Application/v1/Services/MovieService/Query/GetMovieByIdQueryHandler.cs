using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, ResponseMessage>
    {
        private readonly IMoviesRepository _moviesRepository;
        public GetMovieByIdQueryHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<ResponseMessage> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.GetMovieByIdAsync(movieId: request.MovieId);
        }
    }
}