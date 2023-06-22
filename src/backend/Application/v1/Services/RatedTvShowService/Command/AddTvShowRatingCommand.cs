using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.RatedTvShowService.Command
{
    public class AddTvShowRatingCommand : IRequest<ResponseMessage>
    {
        public RatedTvShowDto RatedTvShowDto { get; set; }
        public AppUser User { get; set; }
    }
}