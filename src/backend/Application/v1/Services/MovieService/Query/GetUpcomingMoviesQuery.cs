using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class GetUpcomingMoviesQuery : IRequest<ResponseMessage>
    {
        public int Page { get; set; }
    }
}