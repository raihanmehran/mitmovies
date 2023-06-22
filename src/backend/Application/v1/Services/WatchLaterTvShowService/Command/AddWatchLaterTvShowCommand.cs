using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.WatchLaterTvShowService.Command
{
    public class AddWatchLaterTvShowCommand : IRequest<ResponseMessage>
    {
        public WatchLaterDto WatchLaterDto { get; set; }
        public AppUser User { get; set; }
    }
}