using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.WatchedTvShowService.Command
{
    public class RemoveTvShowFromWatchedCommand : IRequest<ResponseMessage>
    {
        public int TvShowId { get; set; }
        public AppUser User { get; set; }
    }
}