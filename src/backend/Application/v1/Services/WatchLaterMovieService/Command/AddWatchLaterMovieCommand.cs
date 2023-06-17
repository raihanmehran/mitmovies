using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.WatchLaterMovieService.Command
{
    public class AddWatchLaterMovieCommand : IRequest<ResponseMessage>
    {
        public WatchLaterDto WatchLaterMovieDto { get; set; }
        public AppUser User { get; set; }
    }
}