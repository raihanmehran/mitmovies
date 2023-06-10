using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.TrendingMoviesService.Query
{
    public class GetTodayTrendingMoviesQuery : IRequest<ResponseMessage>
    {
    }
}