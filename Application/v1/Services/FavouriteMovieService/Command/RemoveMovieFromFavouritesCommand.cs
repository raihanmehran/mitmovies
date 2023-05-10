using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.FavouriteMovieService.Command
{
    public class RemoveMovieFromFavouritesCommand : IRequest<ResponseMessage>
    {
        public int MovieId { get; set; }
        public AppUser User { get; set; }
    }
}