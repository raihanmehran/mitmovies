using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.TrendingMoviesService.Query
{
    public class GetTodayTrendingMoviesQueryHandler : IRequestHandler<GetTodayTrendingMoviesQuery, ResponseMessage>
    {
        private readonly ITrendingMoviesRepository _trendingMoviesRepository;
        public GetTodayTrendingMoviesQueryHandler(ITrendingMoviesRepository trendingMoviesRepository)
        {
            _trendingMoviesRepository = trendingMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetTodayTrendingMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _trendingMoviesRepository.GetTodayTrendingMovies();
        }
    }
}