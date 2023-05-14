using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.GenreService.Command
{
    public class UpdateGenreCommand : IRequest<ResponseMessage>
    {
        public GenreDto Genre { get; set; }
    }
}