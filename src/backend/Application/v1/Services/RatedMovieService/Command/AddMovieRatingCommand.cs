using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.RatedMovieService.Command
{
    public class AddMovieRatingCommand : IRequest<ResponseMessage>
    {
        public RatedMovieDto RatedMovieDto { get; set; }
        public AppUser User { get; set; }
    }
}