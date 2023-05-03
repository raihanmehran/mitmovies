using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class GetTopRatedMoviesQueryHandler : IRequestHandler<GetTopRatedMoviesQuery, ResponseMessage>
    {
        private readonly IMoviesRepository _moviesRepository;
        public GetTopRatedMoviesQueryHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetTopRatedMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.GetTopRatedMovies();
        }
    }
}