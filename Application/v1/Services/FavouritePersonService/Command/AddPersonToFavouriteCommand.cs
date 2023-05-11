using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.FavouritePersonService.Command
{
    public class AddPersonToFavouriteCommand:IRequest<ResponseMessage>
    {
        public int PersonId { get; set; }
        public AppUser User { get; set; }
    }
}