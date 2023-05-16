using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.TvShowService.Query
{
    public class GetTvShowByIdQuery : IRequest<ResponseMessage>
    {
        public int TvShowId { get; set; }
    }
}