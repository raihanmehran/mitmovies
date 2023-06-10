using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class GetMovieByIdQuery : IRequest<ResponseMessage>
    {
        public int MovieId { get; set; }
    }
}