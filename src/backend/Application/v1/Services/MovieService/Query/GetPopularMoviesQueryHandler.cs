using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class GetPopularMoviesQueryHandler : IRequestHandler<GetPopularMoviesQuery, ResponseMessage>
    {
        private readonly IMoviesRepository _moviesRepository;
        public GetPopularMoviesQueryHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetPopularMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.GetPopularMoviesAsync(page: request.Page);
        }
    }
}