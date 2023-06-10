using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetTrendingTvShowsQuery : IRequest<ResponseMessage>
    {
        public string TimeWindow { get; set; }
    }
}