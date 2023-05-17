using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.FavouritePersonService.Query
{
    public class GetFavouritePeopleQuery:IRequest<ResponseMessage>
    {
        public AppUser User { get; set; }
    }
}