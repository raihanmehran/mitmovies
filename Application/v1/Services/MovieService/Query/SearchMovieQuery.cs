using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.MovieService.Query
{
    public class SearchMovieQuery : IRequest<ResponseMessage>
    {
        public string Payload { get; set; }
    }
}