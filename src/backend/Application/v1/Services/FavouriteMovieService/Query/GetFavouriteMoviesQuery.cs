using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.FavouriteMovieService.Query
{
    public class GetFavouriteMoviesQuery:IRequest<ResponseMessage>
    {
        public AppUser User { get; set; }
    }
}