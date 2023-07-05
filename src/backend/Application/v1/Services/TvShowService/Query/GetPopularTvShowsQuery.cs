using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetPopularTvShowsQuery : IRequest<ResponseMessage>
    {
        public int Page { get; set; }
    }
}