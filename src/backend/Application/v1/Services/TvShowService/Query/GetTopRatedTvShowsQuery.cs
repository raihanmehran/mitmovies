using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetTopRatedTvShowsQuery : IRequest<ResponseMessage>
    {
        public int Page { get; set; }
    }
}