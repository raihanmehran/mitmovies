using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.WatchLaterTvShowService.Command
{
    public class RemoveWatchLaterTvShowCommand : IRequest<ResponseMessage>
    {
        public int TvShowId { get; set; }
        public AppUser User { get; set; }
    }
}