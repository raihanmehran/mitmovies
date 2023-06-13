using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.RatedMovieService.Command
{
    public class RemoveMovieRatingCommand : IRequest<ResponseMessage>
    {
        public int MovieId { get; set; }
        public AppUser User { get; set; }
    }
}