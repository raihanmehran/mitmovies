using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class GetUpcomingMoviesQueryHandler : IRequestHandler<GetUpcomingMoviesQuery, ResponseMessage>
    {
        private readonly IMoviesRepository _moviesRepository;
        public GetUpcomingMoviesQueryHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetUpcomingMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.GetUpcomingMoviesAsync();
        }
    }
}