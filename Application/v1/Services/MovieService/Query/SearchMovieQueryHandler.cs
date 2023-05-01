using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class SearchMovieQueryHandler : IRequestHandler<SearchMovieQuery, ResponseMessage>
    {
        private readonly IMoviesRepository _moviesRepository;
        public SearchMovieQueryHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<ResponseMessage> Handle(SearchMovieQuery request, CancellationToken cancellationToken)
        {
            return await _moviesRepository.SearchMovie(payload: request.Payload);
        }
    }
}