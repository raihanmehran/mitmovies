using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.UserGenreService.Command
{
    public class UpdateUserGenresCommand : IRequest<ResponseMessage>
    {
        public string Genres { get; set; }
        public AppUser User { get; set; }
    }
}