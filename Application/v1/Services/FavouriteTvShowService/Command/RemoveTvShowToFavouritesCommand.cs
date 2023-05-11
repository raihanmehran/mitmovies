using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.FavouriteTvShowService.Command
{
    public class RemoveTvShowToFavouritesCommand : IRequest<ResponseMessage>
    {
        public int TvShowId { get; set; }
        public AppUser User { get; set; }
    }
}