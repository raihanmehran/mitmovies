using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.GenreService.Query
{
    public class GetGenreByIdQuery : IRequest<ResponseMessage>
    {
        public int GenreId { get; set; }
    }
}