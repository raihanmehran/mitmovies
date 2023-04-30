using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class GetMovieDetailByIdQueryHandler : IRequestHandler<GetMovieDetailByIdQuery, ResponseMessage>
    {
        private readonly IMoviesRepository _moviesRepository;
        public GetMovieDetailByIdQueryHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetMovieDetailByIdQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.GetMovieDetailById(movieId: request.MovieId);
        }
    }
}