using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.TrendingMoviesService.Query
{
    public class GetThisWeekTrendingMoviesQueryHandler : IRequestHandler<GetThisWeekTrendingMoviesQuery, ResponseMessage>
    {
        private readonly ITrendingMoviesRepository _trendingMoviesRepository;
        public GetThisWeekTrendingMoviesQueryHandler(ITrendingMoviesRepository trendingMoviesRepository)
        {
            _trendingMoviesRepository = trendingMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetThisWeekTrendingMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _trendingMoviesRepository.GetThisWeekTrendingMovies();
        }
    }
}